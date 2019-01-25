﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Holder : MonoBehaviour {

	public GameObject highlight;
	protected bool containsBall = false;
	protected RuneBall ball;
	protected int colliding = 0;
	protected bool locked = false;
	

	void Awake () {
		highlight.SetActive(false);
	}

	void Start() {
	}
	
	void Update () {
		
	}

	
	public void ChildTriggerEnter(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("RuneBall")){
				colliding++;
				highlight.SetActive(true);
			}
		}
	}

	public void ChildTriggerExit(Collider collision) {
		GameObject go = collision.gameObject;
		if(go.tag.Equals("RuneBall")){
			colliding--;
			if(colliding == 0){
				highlight.SetActive(false);
				containsBall = false;
				ball = null;
			}
		}
	}

	public void ChildTriggerStay(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("RuneBall")){
				RuneBall runeBall = go.GetComponent<RuneBall>();
				if(!runeBall.isGrasped()){
					highlight.SetActive(false);
					go.transform.position = transform.position; //TWEAK THIS
					setRuneBall(runeBall);
				}
			}
		}
	}

	protected abstract void setRuneBall(RuneBall ball);

	

	//TODO When ball is in collider -> turn on highlighter while ball still grabbed. When let go release into defined spot.
}
