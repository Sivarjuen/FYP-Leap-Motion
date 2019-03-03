using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour {

	private bool on = false;
	private Material _material;
	public int color;
	public int shape;
	private Color offColor;
	private Color onColor;
	private Color targetColor;
	public GameObject shapeObj;
	private bool matched = false;
	public Puzzle puzzle;

	void Start () {
		Renderer renderer = GetComponent<Renderer>();
		if (renderer == null) {
			renderer = GetComponentInChildren<Renderer>();
		}
		if (renderer != null) {
			_material = renderer.material;
		}
		offColor = _material.color;
		targetColor = offColor;
		shapeObj.SetActive(false);
		getTargetColor();
	}
	
	void Update () {
      	_material.color = targetColor;
	}

	private void toggle(){
		if(on && !matched){
			on = false;
			targetColor = offColor;
			shapeObj.SetActive(false);
		} else {
			on = true;
			targetColor = onColor;
			shapeObj.SetActive(true);
		}
	}

	public void manualToggle(){
		if(!matched){
			toggle();
			StartCoroutine("sendMove");
		}
	}

	IEnumerator sendMove(){
		yield return new WaitForSeconds(.3f);
		puzzle.toggleReceived(this);
		yield return null;
	}

	public void autoToggle(){
		toggle();
	}

	private void getTargetColor(){
		switch(color){
			case 1:
				onColor = Color.blue;
				break;
			case 2:
				onColor = Color.green;
				break;
			case 3:
				onColor = Color.red;
				break;
			case 4:
				onColor = Color.yellow;
				break;
			case 5:
				onColor = Color.magenta;
				break;
			case 6:
				onColor = Color.cyan;
				break;
			case 7:
				onColor = new Color(1, 0.5f, 0, 1);
				break;
			case 8:
				onColor = new Color(0.25f, 0, 0.5f, 1);
				break;
		}
	}

	public void setMatched(){
		matched = true;
		on = true;
		targetColor = onColor;
		shapeObj.SetActive(true);
	}

	public bool isOn(){
		return on;
	}
}
