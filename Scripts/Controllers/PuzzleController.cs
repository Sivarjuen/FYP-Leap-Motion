using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour {

	public Transform target;
	public GameObject hints;

	private float timer;
	private float duration = 2.0f;
	private bool active = false;
	
	void Start() {
		hints.SetActive(false);
	}


	void Update () {
		if(active){
			Debug.Log(Time.time - timer);
			if(Time.time > timer + duration){
				active = false;
				this.gameObject.SetActive(false);
			} else {
				transform.position = Vector3.Lerp(transform.position, target.position, 0.2f * Time.deltaTime);
			}
		}
	}

	public void activate(){
		if(!active){
			hints.SetActive(true);
			active = true;
			timer = Time.time;
		}
	}
}
