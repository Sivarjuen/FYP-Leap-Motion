using Leap.Unity;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionBehaviour))]
public class PowerButton : MonoBehaviour {

	private bool on;
	public bool startOn = false;
	private Material _material;
	private Color onColor = Color.green;
	private Color offColor;
	private Color targetColor;
	private InteractionBehaviour _intObj;
	private float toggleDelay = .2f;
	private float toggleTimer = 0;
	private PowerButton[] adjacentButtons;

	void Start () {
		on = startOn;
		 _intObj = GetComponent<InteractionBehaviour>();

		Renderer renderer = GetComponent<Renderer>();
		if (renderer == null) {
		renderer = GetComponentInChildren<Renderer>();
		}
		if (renderer != null) {
		_material = renderer.material;
		}
		offColor = _material.color;
		if(on){
			targetColor = onColor;
			_material.color = onColor;
		} else {
			targetColor = offColor;
		}
	}
	
	void Update () {
		// Lerp actual material color to the target color.
      	_material.color = Color.Lerp(_material.color, targetColor, 30F * Time.deltaTime);
	}

	private void toggle(){
		if(Time.time - toggleTimer >= toggleDelay){
			if(on){
				on = false;
				targetColor = offColor;
			} else {
				on = true;
				targetColor = onColor;
			}
			toggleTimer = Time.time;
		}
	}

	private void autoToggle(){
		toggle();
	}

	public void manualToggle(){
		toggle();
		foreach(PowerButton b in adjacentButtons){
			b.autoToggle();
		}
	}

	public bool isOn(){
		return on;
	}

	public void setAdjacentButtons(PowerButton[] buttons){
		this.adjacentButtons = buttons;
	}
}
