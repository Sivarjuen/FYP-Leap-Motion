using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class RomanBall : MonoBehaviour {

	private bool grasped;
	private InteractionBehaviour interactionScript;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;
	private Rigidbody rb;
	
	private void Awake() {
		this.grasped = false;
	}
	
	private void Start(){
		interactionScript = GetComponent<InteractionBehaviour>();
		rb = GetComponent<Rigidbody>();
		this.spawnPosition = transform.position;
		this.spawnRotation = transform.rotation;
		spawnPosition.y += 0.1f;
	}
	
	private void Update() {
		if(!grasped && interactionScript.isGrasped){
			grasped = true;
		}
		if(grasped && !interactionScript.isGrasped){
			grasped = false;
		}
	}

	public bool isGrasped(){
		return this.grasped;
	}

	public void respawn(){
		transform.position = spawnPosition;
		transform.rotation = spawnRotation;
		rb.velocity = Vector3.zero;
	}

	public void stopMovement(){
		rb.velocity = Vector3.zero;
	}

	public void stopContact(){
		stopMovement();
		interactionScript.ignoreContact = true;
	}

	public void freeze(){
		stopContact();
		interactionScript.ignoreGrasping = true;
	}

	
}
