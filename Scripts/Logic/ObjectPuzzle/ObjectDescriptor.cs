using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class ObjectDescriptor : MonoBehaviour {

	public int colour, sides;
	private bool grasped;
	private InteractionBehaviour interactionScript;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;
	private Rigidbody rb;

	private void Awake(){
		this.grasped = false;
	}


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		interactionScript = GetComponent<InteractionBehaviour>();
		this.spawnPosition = transform.position;
		this.spawnRotation = transform.rotation;
		spawnPosition.y += 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!grasped && interactionScript.isGrasped){
			grasped = true;
		}
		if(grasped && !interactionScript.isGrasped){
			grasped = false;
		}
	}

	public int getColour(){
		return this.colour;
	}

	public int getSides(){
		return this.sides;
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
