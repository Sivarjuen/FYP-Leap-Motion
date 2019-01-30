using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class RuneBall : MonoBehaviour {

	private int number; // 1, 2, 3, 4
	private int colour; // 1 = Green, 2 = Orange, 3 = Purple, 4 = Blue
	private bool grasped ;
	public Material[] materials; // 0 - Grey, 1-4 Green, 5-8 Orange, 9-12 Purple, 13-16 Blue
	private Renderer renderer;
	private InteractionBehaviour interactionScript;
	private bool locked = false;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;
	private Rigidbody rb;

	private void Awake() {
		this.number = 1;
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

	public void changeColour(){
		if(this.colour == 4){
			this.colour = 1;
		} else{
			this.colour++;
		}
		changeTexture();
	}

	public void changeNumber(){
		if(this.colour != 0){
			if(this.number == 4){
				this.number = 1;
			} else{
				this.number++;
			}
			changeTexture();
		}
	}

	public int getNumber(){
		return this.number;
	}

	public int getColour(){
		return this.colour;
	}

	public bool isGrasped(){
		return this.grasped;
	}

	private void changeTexture(){
		int index = ((colour-1) * 4) + number;
		
		this.renderer.material = materials[index];
		Debug.Log("Texture changed!");
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
		//rb.constraints = RigidbodyConstraints.FreezeAll;
		stopContact();
		interactionScript.ignoreGrasping = true;
	}
}
