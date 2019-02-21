using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {

	public GameObject[] platforms;
	public Transform furthestPlatform, closestPlatform, leftMostPlatform, rightMostPlatform;
	private float minZ, maxZ, minX, maxX;
	private GameObject nearestPlatform;
	private Vector3 nearestPosition;
	private float speed = 0.03f;
	private int movement = 0; // 0 = stationary, 1 = move up, 2 = move down, 3 = move left, 4 = move right
	private bool active;
	private Block block;
	private bool containsBlock;

	
	// Use this for initialization
	void Start () {
		containsBlock = false;
		active = false;
		minZ = furthestPlatform.position.z;
		maxZ = closestPlatform.position.z;
		minX = rightMostPlatform.position.x;
		maxX = leftMostPlatform.position.x;
		findNearestPlatform();
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			Vector3 current = transform.position;
			findNearestPlatform();
			if(movement == 0){
				transform.position = Vector3.Lerp(current, nearestPosition, 5 * Time.deltaTime);
			} else {
				if(movement == 1){
					if(current.z > minZ){
						current.z = current.z - speed;
					}
				} else if(movement == 2){
					if(current.z < maxZ){
						current.z = current.z + speed;
					}
				} else if(movement == 3){
					if(current.x < maxX){
						current.x = current.x + speed;
					}
				} else if(movement == 4){
					if(current.x > minX){
						current.x = current.x - speed;
					}
				}
				transform.position = current;
			}
		}
	}

	private void updateHighlightedPlatform(){
		foreach(GameObject p in platforms){
			PlatformController pc = p.GetComponent<PlatformController>();
			if(p.Equals(nearestPlatform)){
				pc.setHighlight(true);
			} else {
				pc.setHighlight(false);
			}
		}
	}

	private void findNearestPlatform(){
		Vector3 target = transform.position;
		GameObject highlightedPlatform = platforms[0];
		Vector3 closestPlatform = platforms[0].transform.position;
		float smallestDistance = 9999999999;

		foreach(GameObject p in platforms){
			Vector3 current = p.transform.position;
			float xDiff = target.x - current.x; 
			float zDiff = target.z - current.z;
			float dist = Mathf.Sqrt(xDiff*xDiff + zDiff*zDiff);
			if(dist < smallestDistance){
				smallestDistance = dist;
				closestPlatform = current;
				highlightedPlatform = p;
			}
		}

		target.x = closestPlatform.x;
		target.z = closestPlatform.z;

		nearestPosition = target;
		nearestPlatform = highlightedPlatform;
		updateHighlightedPlatform();
	}

	public void moveUp(){
		movement = 1;
	}

	public void moveDown(){
		movement = 2;
	}

	public void moveLeft(){
		movement = 3;
	}

	public void moveRight(){
		movement = 4;
	}

	public void stop(){
		movement = 0;
	}

	public void activate(){
		active = true;
	}

	public bool hasBlock(){
		return containsBlock;
	}

	public void setBlock(Block block){
		this.block = block;
		containsBlock = true;
	}

	public void removeBlock(){
		containsBlock = false;
		block = null;
	}
}
