using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Controller : MonoBehaviour {

	public Image tube1, tube2, tube3, tube4;
	private int filling = 0; //0 - No Tubes active, n - Tube n being filled
	private bool[] filled;
	private float timer = 0.0f;
	private float fillDuration = 4.0f;

	// Use this for initialization
	void Start () {
		initialiseTubes();
	}
	
	// Update is called once per frame
	void Update () {
		updateTubes();
	}

	public void activate(int n){
		filling = n;
		timer = Time.time;
	}

	private void initialiseTubes(){
		tube1.fillAmount = 0.0f;
		tube2.fillAmount = 0.0f;
		tube3.fillAmount = 0.0f;
		tube4.fillAmount = 0.0f;
		filled = new bool[4];
		for(int i = 0; i < filled.Length; i++) filled[i] = false;
	}

	private void updateTubes(){
		switch(filling){
			case 1:
				fillTube(tube1, 0);
				break;
			case 2:
				fillTube(tube2, 1);
				break;
			case 3:
				fillTube(tube3, 2);
				break;
			case 4:
				fillTube(tube4, 3);
				break;
		}
	}

	private void fillTube(Image tube, int n){
		float elapsed = Time.time - timer;
		if(tube.fillAmount < 1.0f){
			tube.fillAmount = elapsed / fillDuration;
		}
		if(tube.fillAmount >= 1.0f){
			filling = 0;
			filled[n] = true;
		}
	}
}
