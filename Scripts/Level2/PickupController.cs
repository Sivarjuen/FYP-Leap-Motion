using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	private bool leftExtended, rightExtended, leftClosed, rightClosed;
	private float timer = 0;
	private float delay = 1.0f;
	private bool extended = false;
	private bool pickup = false;
	public ArmController arm;
	private float maxHeight;
	private float minHeight;
	private bool inProgress = false;
	private int movementState = 0; // 0 - nothing, 1 - moving down, 2 - moving up
	private int state = 0; // 0 - nothing, 1 - dropping, 2 - picking up
	private float speed = 0.02f;

	// Use this for initialization
	void Start () {
		 maxHeight = arm.transform.position.y;
		 minHeight = 1.25f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!pickup && extended){
			if(Time.time > timer + delay){
				if(!leftExtended || !rightExtended) extended = false;
			}
		}
		if(pickup){
			PlatformController pc = arm.nearestPlatformGO().GetComponent<PlatformController>();
			if(!inProgress){
				bool blockArm = arm.hasBlock();
				bool blockPlatform = pc.hasBlock();
				if(blockArm && !blockPlatform){
					state = 1; //dropping
				} else if(!blockArm && blockPlatform){
					state = 2; //picking up
				}
				movementState = 1;
				inProgress = true;
			} else {
				Vector3 current = arm.transform.position;
				//move down to minHeight
				if(movementState == 1){
					if(current.y <= minHeight){
						current.y = minHeight;
						//follow state (nothing, dropping or picking?)
						if(state == 1){
							pc.setBlock(arm.getBlock());
							arm.removeBlock();
						} else if(state == 2){
							arm.setBlock(pc.getBlock());
							pc.removeBlock();
						}
						movementState = 2;
					} else {
						current.y = current.y - speed;
						if(arm.hasBlock()){
							Vector3 blockPosition = arm.getBlock().transform.position;
							blockPosition.y = blockPosition.y - speed;
							arm.getBlock().transform.position = blockPosition;
						}
					}
				} else if(movementState == 2){ //move up to maxHeight
					if(current.y >= maxHeight){
						current.y = maxHeight;
						//reset everything here
						movementState = 0;
						state = 0;
						inProgress = false;
						pickup = false;
					} else {
						current.y = current.y + speed;
						if(arm.hasBlock()){
							Vector3 blockPosition = arm.getBlock().transform.position;
							blockPosition.y = blockPosition.y + speed; 
							arm.getBlock().transform.position = blockPosition;
						}
					}
				}
				arm.transform.position = current;	
			}
			
		}
	}

	public void extendLeft(bool b){
		leftExtended = b;
		if(!extended && !pickup){
			if(b && rightExtended){
				extended = true;
				timer = Time.time;
			}
		}
	}

	public void extendRight(bool b){
		rightExtended = b;
		if(!extended && !pickup){
			if(b && leftExtended){
				extended = true;
				timer = Time.time;
			}
		}
	}

	public void closeLeft(bool b){
		leftClosed = b;
		if(extended && !pickup){
			if(b && rightClosed){
				pickup = true;
				timer = Time.time;
			}
		}
	}

	public void closeRight(bool b){
		rightClosed = b;
		if(extended && !pickup){
			if(b && leftClosed){
				pickup = true;
				timer = Time.time;
			}
		}
	}
}
