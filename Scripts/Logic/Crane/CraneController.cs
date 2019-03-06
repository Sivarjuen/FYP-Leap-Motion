using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity.Interaction;

public class CraneController : MonoBehaviour {

	private float limit = 0.004f;
	private float centerLimit = 0.002f;
	private Vector3 center;
	private bool grasped;
	private InteractionBehaviour interactionScript;
	public Transform topHard, topSoft, botHard, botSoft, leftHard, leftSoft, rightHard, rightSoft;
	public ArmController arm;
	private Color onColor = Color.green;
	public Renderer lightRenderer;
	private float lastX;
	private float lastY;
	private int state = 0; // 0 - at center, 1 - moving vertically, 2 - moving horizontally
	private int lastState = 0;
	private float stateTimer = 0.0f;
	private float stateDelay = 0.1f;

	// Use this for initialization
	void Start () {
		grasped = false;
		center = transform.position;
		interactionScript = GetComponent<InteractionBehaviour>();
		lastX = center.x;
		lastY = center.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z != center.z){
			Vector3 tempPosition = transform.position;
				tempPosition.z = center.z;
				transform.position = tempPosition;
		}
		updateGrasped();
		Vector3 newPosition = transform.position;
		float centerDiffX = Mathf.Abs(newPosition.x - center.x);
		float centerDiffY = Mathf.Abs(newPosition.y - center.y);
		if(centerDiffX < centerLimit && centerDiffY < centerLimit){
			state = 0;
		}
		if(state == 0){
			if(Time.time > stateTimer + stateDelay){
				if(centerDiffX > centerLimit || centerDiffY > centerLimit){
					if(centerDiffX > centerDiffY){
						state = 2;
					} else {
						state = 1;
					}
				}
			} else if(centerDiffX > centerLimit && lastState==2){
				state = 2;

			} else if(centerDiffY > centerLimit && lastState==1){
				state = 1;
			} else {
				newPosition = center;
			}
		}
		print(state + " ");
		if(grasped){
			if(state == 1){
				lastState = 1;
				stateTimer = Time.time;
				Vector3 tempPosition = transform.position;
				tempPosition.x = center.x;
				newPosition = tempPosition;
				lastX = newPosition.x;
			} else if(state == 2){
				lastState = 2;
				stateTimer = Time.time;
				Vector3 tempPosition = transform.position;
				tempPosition.y = center.y;
				newPosition = tempPosition;
				lastY = newPosition.y;
			}
		} else {
			newPosition = Vector3.Lerp(transform.position, center, 5 * Time.deltaTime);
		}
		float newX = newPosition.x;
		float newY = newPosition.y;

		float speed = 0.002f;
		if(newX - lastX > speed) newX = lastX + speed;
		if(newX - lastX < -speed) newX = lastX - speed;
		if(newY - lastY > speed) newY = lastY + speed;
		if(newX - lastX < -speed) newY = lastY - speed;

		newPosition.x = newX;
		newPosition.y = newY;
		transform.position = newPosition;
		lastX = transform.position.x;
		lastY = transform.position.y;
		checkHardLimits();
		checkSoftLimits();
	}

	private void updateGrasped(){
		if(!grasped && interactionScript.isGrasped){
			grasped = true;
		}
		if(grasped && !interactionScript.isGrasped){
			grasped = false;
		}
	}

	private void checkHardLimits(){
		float x = transform.position.x;
		float y = transform.position.y;
		if(x > leftHard.position.x) transform.position = leftHard.position;
		if(x < rightHard.position.x) transform.position = rightHard.position;
		if(y > topHard.position.y) transform.position = topHard.position;
		if(y < botHard.position.y) transform.position = botHard.position;
	}

	private void checkSoftLimits(){
		float x = transform.position.x;
		float y = transform.position.y;
		if(x > leftSoft.position.x){
			arm.moveLeft();
		} else if(x < rightSoft.position.x){
			arm.moveRight();
		} else if(y > topSoft.position.y){
			arm.moveUp();
		} else if(y < botSoft.position.y){
			arm.moveDown();
		} else {
			arm.stop();
		}
	}

	public void activate(){
		lightRenderer.material.color = onColor;
	}


}
