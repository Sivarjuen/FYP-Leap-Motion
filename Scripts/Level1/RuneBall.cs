using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBall : MonoBehaviour {

	private int number; // 1, 2, 3, 4
	private int colour; // 1 = Purple, 2 = Green, 3 = Orange, 4 = Blue
	private bool grasped ;
	public Material[] materials; // 0-3 Purple, 4-7 Green, 8-11 Orange, 12-15 Blue
	private Material material;

	private void Awake() {
		this.number = 0;
		this.colour = 0;
		this.grasped = false;
	}

	private void Start(){
		material = GetComponent<Renderer>().material;
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

	public void setGrasped(bool grasped){
		this.grasped = grasped;
	}

	private void changeTexture(){
		int index = ((colour-1) * 4) + number - 1;
		material = materials[index];
	}
}
