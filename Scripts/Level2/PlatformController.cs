using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject highlight; 
	
	void Awake() {
		highlight.SetActive(false);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setHighlight(bool b){
		highlight.SetActive(b);
	}
}
