using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private int type; // 0 = blue, 1 = red, 2 = green, 3 = yellow, 4 = purple
	private Renderer renderer;

	public void initialise(int type){
		this.type = type;
		renderer = GetComponent<Renderer>();
		setColour();
	}

	private void setColour(){
		switch(type){
			case 0:
				renderer.material.color = Color.blue;
				break;
			case 1:
				renderer.material.color = Color.red;
				break;
			case 2:
				renderer.material.color = Color.green;
				break;
			case 3:
				renderer.material.color = Color.yellow;
				break;
			case 4:
				renderer.material.color = Color.magenta;
				break;
		}
	}

	public int getType(){
		return type;
	}
}
