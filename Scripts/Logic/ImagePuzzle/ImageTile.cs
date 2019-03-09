using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTile : MonoBehaviour {

	private Renderer _renderer;
	private int colour; // 1 - green, 2 - blue, 3 - yellow, 4 - purple
	
	void Awake () {
		_renderer = GetComponent<Renderer>();
		if(_renderer == null){
			_renderer = GetComponentInChildren<Renderer>();
		}
	}

	private void changeColour(){
		switch(colour){
			case 1:
				_renderer.material.color = Color.green;
				break;
			case 2:
				_renderer.material.color = Color.blue;
				break;
			case 3:
				_renderer.material.color = Color.yellow;
				break;
			case 4:
				_renderer.material.color = Color.magenta;
				break;
		}
	}

	public void toggleColour(){
		if(colour == 4){
			colour = 1;
		} else {
			colour++;
		}
		changeColour();
	}

	public int getColour(){
		return colour;
	}

	public void setColour(int n){
		colour = n;
		changeColour();
	}
}
