using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class RuneBall : MonoBehaviour {

	private int number; // 1, 2, 3, 4
	private int colour; // 1 = Green, 2 = Orange, 3 = Purple, 4 = Blue
	private bool grasped ;
	public Material[] materials; // 0-3 Green, 4-7 Orange, 8-11 Purple, 12-15 Blue
	private Material material;
	private InteractionBehaviour interactionScript;
	private bool locked = false;

	private void Awake() {
		this.number = 0;
		this.colour = 0;
		this.grasped = false;
	}

	private void Start(){
		material = GetComponent<Renderer>().material;
		interactionScript = GetComponent<InteractionBehaviour>();
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
		if(this.number == 4){
			this.number = 1;
		} else{
			this.number++;
		}
		changeTexture();
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
		int index = ((colour-1) * 4) + number - 1;
		material = materials[index];
	}
}
