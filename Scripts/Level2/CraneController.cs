using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity.Interaction;

public class CraneController : MonoBehaviour {

	private float limit = 0.008f;
	private Vector3 center;
	private bool grasped;
	private InteractionBehaviour interactionScript;
	public Transform topHard, topSoft, botHard, botSoft, leftHard, leftSoft, rightHard, rightSoft;
	public ArmController arm;
	private Color onColor = Color.green;
	public Renderer lightRenderer;

	// Use this for initialization
	void Start () {
		grasped = false;
		center = transform.position;
		interactionScript = GetComponent<InteractionBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z != center.z){
			Vector3 tempPosition = transform.position;
				tempPosition.z = center.z;
				transform.position = tempPosition;
		}
		updateGrasped();
		if(grasped){
			if(transform.position.x > center.x + limit || transform.position.x < center.x - limit){
				Vector3 tempPosition = transform.position;
				tempPosition.y = center.y;
				transform.position = tempPosition;
			} else if(transform.position.y > center.y + limit || transform.position.y < center.y - limit){
				Vector3 tempPosition = transform.position;
				tempPosition.x = center.x;
				transform.position = tempPosition;
			}
		} else {
			transform.position = Vector3.Lerp(transform.position, center, 5 * Time.deltaTime);
		}

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
