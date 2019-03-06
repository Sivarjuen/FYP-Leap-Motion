using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class UpDownNavigation : MonoBehaviour {

	public LeapProvider LeapDataProvider;
	public GameObject leapRig;
	private float timer = 0.0f;
	private float duration = 0.2f;
	private float lockDuration = 5.0f;
	private int timerState = 0;	// 0 - not active, 1 - timing upwards movement, 2 - timing downwards movement
	private int cameraState = 0; // 0 - not moving, 1 - moving upwards, 2 - moving downwards, 3 - locked, 4 - permanent lock
	private Quaternion targetRotation;
	private Vector3 targetPosition;
	private bool leftPalmDown = false;
	private bool rightPalmDown = false;
	private bool leftPalmUp = false;
	private bool rightPalmUp = false;
	public bool facingUp = true;
	private bool lockPending = false;
	private Frame curFrame;
	public bool active = true;
	public bool usePoints = false;
	public GameObject pointUp, pointDown;
	
	void Start(){
		targetRotation = leapRig.transform.rotation;
	}
	
	void Update () {

		if(active){
			curFrame = LeapDataProvider.CurrentFrame;
			if(cameraState == 0 && curFrame.Hands.Count == 2){
				if(leftPalmUp && rightPalmUp){
					if(timerState == 0 || timerState == 1){
						if(!facingUp){
							timer = Time.time;
							timerState = 1;
						}
					} else if(timerState == 2) {
							moveCameraDown();
					} 
				} else if(leftPalmDown && rightPalmDown){
					
					if(timerState == 0 || timerState == 2){
						if(facingUp){
							timer = Time.time;
							timerState = 2;
						}
					} else if(timerState == 1) {
							moveCameraUp();
					}
				} else {
					if(Time.time - timer >= duration){
						if(timerState == 1){
							moveCameraUp();
						} else if (timerState == 2){
							moveCameraDown();
						}
					}
				}
			} else if(cameraState == 1 || cameraState == 2){
				leapRig.transform.rotation = Quaternion.Lerp (leapRig.transform.rotation, targetRotation , 10 * 1f * Time.deltaTime); 
				if(usePoints){
					leapRig.transform.position = Vector3.Lerp (leapRig.transform.position, targetPosition , 10 * 1f * Time.deltaTime); 
				}
				if(leapRig.transform.rotation == targetRotation){
					if(!usePoints || (usePoints && leapRig.transform.position == targetPosition)){
						if(lockPending){
							lockCamera();
						} else {
							cameraState = 0;
						}
					}
				}
				if(Time.time > timer + 3.0f){	// Forces camera to target position if it gets stuck after 3 secs
					cameraState = 0;
					leapRig.transform.position = targetPosition;
					leapRig.transform.rotation = targetRotation;
				}
			} else if(cameraState == 3){
				if(Time.time - timer >= lockDuration){
					Debug.Log("Camera Unlocked");
					lockPending = false;
					cameraState = 0;
				}
			} else if(cameraState == 4){
				//do nothing
			}
		}
	}

	public void setLeftPalmDown(bool b){
		leftPalmDown = b;
	}

	public void setRightPalmDown(bool b){
		rightPalmDown = b;
	}

	public void setLeftPalmUp(bool b){
		leftPalmUp = b;
	}

	public void setRightPalmUp(bool b){
		rightPalmUp = b;
	}

	public void moveCameraUp(){
		if(!facingUp && cameraState != 4){
			facingUp = true;
			timerState = 0;
			timer = Time.time;
			cameraState = 1;
			if(usePoints){
				targetPosition = pointUp.transform.position;
				targetRotation = pointUp.transform.rotation;
			} else {
				targetRotation = Quaternion.Euler(0,0,0);
			}
		}
	}

	public void moveCameraDown(){
		if(facingUp && cameraState != 4){
			facingUp = false;
			timerState = 0;
			timer = Time.time;
			cameraState = 2;
			if(usePoints){
				targetPosition = pointDown.transform.position;
				targetRotation = pointDown.transform.rotation;
			} else {
				targetRotation = Quaternion.Euler(60,0,0);
			}
		}
	}

	public bool isFacingUp(){
		return facingUp;
	}

	private void lockCamera(){
		if(cameraState != 4){
			cameraState = 3;
			timer = Time.time;
			Debug.Log("Camera Locked");
		}
	}

	public void lockPermanently(){
		cameraState = 4;
	}

	public void moveCameraUpandLock(){
		moveCameraUp();
		lockPending = true;
	}

	public void activate(){
		active = true;
	}

	public void deactivate(){
		active = false;
	}
}
