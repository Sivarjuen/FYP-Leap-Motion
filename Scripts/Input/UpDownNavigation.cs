using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownNavigation : MonoBehaviour {

	public GameObject leapRig;
	private float timer = 0.0f;
	private float duration = 0.2f;
	private int timerState = 0;	// 0 - not active, 1 - upwards movement pending, 2 - downwards movement pending
	private bool leftPalmDown = false;
	private bool rightPalmDown = false;
	private bool leftPalmUp = false;
	private bool rightPalmUp = false;
	private bool facingUp = true;
	
	// Update is called once per frame
	void Update () {
		//if(!isGraspingSomething){
			if(leftPalmUp && rightPalmUp){
				if(timerState == 0 || timerState == 1){
					if(!facingUp){
						timer = Time.time;
						timerState = 1;
					}
				} else if(timerState == 2) {
						moveCameraDown(); //TODO
				} 
			} else if(leftPalmDown && rightPalmDown){
				if(timerState == 0 || timerState == 2){
					if(facingUp){
						timer = Time.time;
						timerState = 2;
					}
				} else if(timerState == 1) {
						moveCameraUp(); //TODO
				}
			} else {
				if(Time.time - timer >= duration){
					if(timerState == 1){
						moveCameraUp(); //TODO
					} else if (timerState == 2){
						moveCameraDown(); //TODO
					}
				}
			}
		//}
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
		if(!facingUp){
			facingUp = true;
			timerState = 0;
			Debug.Log("Moving UP");
			leapRig.transform.rotation = Quaternion.Euler(0,0,0);
			// reset timer, state etc.
			//TODO - move camera smoothly
		}
	}

	public void moveCameraDown(){
		if(facingUp){
			facingUp = false;
			timerState = 0;
			Debug.Log("Moving DOWN");
			leapRig.transform.rotation = Quaternion.Euler(60,0,0);
			// reset timer, state etc.
			//TODO - move camera smoothly
		}
	}

	public bool isFacingUp(){
		return facingUp;
	}
}
