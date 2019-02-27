using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class LeftRightNavigation : MonoBehaviour {

	public LeapProvider LeapDataProvider;
	public GameObject leapRig;
	public GameObject point1, point2, point3, point4;
	private float timer = 0.0f;
	private float duration = 0.2f;
	private int timerState = 0; // 0 - not active, 1 - timing left movement, 2 - timing right movement
	private int cameraState = 0; // 0 - not moving, 1 - moving right, 2 - moving left
	
	[HideInInspector]
	public int facing = 0; // 0 - front, 1 - right, 2 - back, 3 - left
	
	private Vector3 targetPosition;
	private Quaternion targetRotation;
	private bool leftPalmLeft = false;
	private bool rightPalmLeft = false;
	private bool leftPalmRight = false;
	private bool rightPalmRight = false;
	private bool reset = false;
	private Frame curFrame;
	public int start;
	private bool lockLeft = false;
	private bool lockRight = false;
	public bool active = true;

	
	// Use this for initialization
	void Start () {
		switch(start){
			case 1:
				targetPosition = point1.transform.position;
				targetRotation = point1.transform.rotation;
				facing = 0;
				return;
			case 2:
				targetPosition = point2.transform.position;
				targetRotation = point2.transform.rotation;
				facing = 1;
				return;
			case 3:
				targetPosition = point3.transform.position;
				targetRotation = point3.transform.rotation;
				facing = 2;
				return;
			case 4:
				targetPosition = point4.transform.position;
				targetRotation = point4.transform.rotation;
				facing = 3;
				return;
			default:
				targetPosition = point1.transform.position;
				targetRotation = point1.transform.rotation;
				facing = 0;
				return;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			curFrame = LeapDataProvider.CurrentFrame;
			if(!leftPalmLeft && !rightPalmLeft && !leftPalmRight && !rightPalmRight){
				reset = false;
			}
			if(cameraState == 0 && curFrame.Hands.Count == 2){
				if(!reset){
					if(leftPalmRight && rightPalmRight && !lockLeft){
						if(timerState == 0 || timerState == 1){
							timer = Time.time;
							timerState = 1;
						} else if(timerState == 2){
							moveCameraRight();
						}
					} else if(leftPalmLeft && rightPalmLeft && !lockRight){
						if(timerState == 0 || timerState == 2){
							timer = Time.time;
							timerState = 2;
						} else if(timerState == 1){
							moveCameraLeft();
						}
					} else {
						if(Time.time - timer >= duration){
							if(timerState == 1){
								moveCameraLeft();
							} else if(timerState == 2){
								moveCameraRight();
							}
						}
					}
				}
			} else {
				leapRig.transform.rotation = Quaternion.Lerp (leapRig.transform.rotation, targetRotation , 10 * Time.deltaTime); 
				leapRig.transform.position = Vector3.Lerp (leapRig.transform.position, targetPosition , 10 * Time.deltaTime); 
				if(leapRig.transform.position == targetPosition){
					cameraState = 0;
				}
			}
		}
	}

	public void setLeftPalmLeft(bool b){
		leftPalmLeft = b;
	}

	public void setRightPalmLeft(bool b){
		rightPalmLeft = b;
	}

	public void setLeftPalmRight(bool b){
		leftPalmRight = b;
	}

	public void setRightPalmRight(bool b){
		rightPalmRight = b;
	}

	public void moveCameraLeft(){
		reset = true;
		timerState = 0;
		cameraState = 2;
		switch(facing){
			case 0:
				facing = 3;
				targetPosition = point4.transform.position;
				targetRotation = point4.transform.rotation;
				break;
			case 1:
				facing = 0;
				targetPosition = point1.transform.position;
				targetRotation = point1.transform.rotation;
				break;
			case 2:
				facing = 1;
				targetPosition = point2.transform.position;
				targetRotation = point2.transform.rotation;
				break;
			case 3:
				facing = 2;
				targetPosition = point3.transform.position;
				targetRotation = point3.transform.rotation;
				break;
		}
	}

	public void moveCameraRight(){
		reset = true;
		timerState = 0;
		cameraState = 1;
		switch(facing){
			case 0:
				facing = 1;
				targetPosition = point2.transform.position;
				targetRotation = point2.transform.rotation;
				break;
			case 1:
				facing = 2;
				targetPosition = point3.transform.position;
				targetRotation = point3.transform.rotation;
				break;
			case 2:
				facing = 3;
				targetPosition = point4.transform.position;
				targetRotation = point4.transform.rotation;
				break;
			case 3:
				facing = 0;
				targetPosition = point1.transform.position;
				targetRotation = point1.transform.rotation;
				break;
		}
	}

	public void lockLeftMovement(bool b){
		lockLeft = b;
	}

	public void lockRightMovement(bool b){
		lockRight = b;
	}

	public void activate(){
		active = true;
	}

	public void deactivate(){
		active = false;
	}
}
