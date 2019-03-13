using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class MathBall : MonoBehaviour {

	private int colour; // 1 = Red, 2 = Blue, 3 = Purple, 4 = Green, 5 = Yellow
	private bool grasped;
	private Renderer renderer;
	private InteractionBehaviour interactionScript;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;
	private Rigidbody rb;
	
	private void Awake() {
		this.colour = 0;
		this.grasped = false;
	}
	
	private void Start(){
		renderer = GetComponent<Renderer>();
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

	public int getColour(){
		return this.colour;
	}

	public bool isGrasped(){
		return this.grasped;
	}

	public void changeColour(){
		if(this.colour == 5){
			this.colour = 1;
		} else{
			this.colour++;
		}

		switch (this.colour) {
			case 1:
				this.renderer.material.color = Color.red;
				break;
			case 2:
				this.renderer.material.color = Color.blue;
				break;
			case 3:
				this.renderer.material.color = Color.magenta;
				break;
			case 4:
				this.renderer.material.color = Color.green;
				break;
			case 5:
				this.renderer.material.color = Color.yellow;
				break;
		}
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
