using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	private bool leftExtended, rightExtended, leftClosed, rightClosed;
	private float timer = 0;
	private float delay = 1.0f;
	private bool extended = false;
	private bool pickup = false;
	private float pickupDuration = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!pickup && extended){
			if(Time.time > timer + delay){
				if(!leftExtended || !rightExtended) extended = false;
			}
		}
		if(pickup){
			if(Time.time < timer + pickupDuration){
				Debug.Log("PICKING UP!");
			} else {
				pickup = false;
			}
		}
	}

	public void extendLeft(bool b){
		leftExtended = b;
		if(!extended && !pickup){
			if(b && rightExtended){
				extended = true;
				timer = Time.time;
			}
		}
	}

	public void extendRight(bool b){
		rightExtended = b;
		if(!extended && !pickup){
			if(b && leftExtended){
				extended = true;
				timer = Time.time;
			}
		}
	}

	public void closeLeft(bool b){
		leftClosed = b;
		if(extended && !pickup){
			if(b && rightClosed){
				pickup = true;
				timer = Time.time;
			}
		}
	}

	public void closeRight(bool b){
		rightClosed = b;
		if(extended && !pickup){
			if(b && leftClosed){
				pickup = true;
				timer = Time.time;
			}
		}
	}
}
