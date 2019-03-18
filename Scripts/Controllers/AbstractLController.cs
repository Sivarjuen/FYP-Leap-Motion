using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class AbstractLController : MonoBehaviour {

	protected int filling = 0; //0 - No Tubes active, n - Tube n being filled
	protected int tubes = -1;
	protected int filled = 0;
	protected float timer = 0.0f;
	protected float fillDuration = 2.5f;
	protected bool complete = false;
	public UpDownNavigation navigation;

	// Use this for initialization
	void Start () {
		initialiseTubes();
	}
	
	// Update is called once per frame
	void Update () {
		updateTubes();
		if(!complete){
			if(filled == tubes) complete = true;
		};
		checkLevelSpecificCriteria();
	}

	public void activate(int n){
		filling = n;
		timer = Time.time;
	}

	protected abstract void initialiseTubes();

	protected abstract void updateTubes();

	protected abstract void checkLevelSpecificCriteria();

	protected void fillTube(Image tube){
		float elapsed = Time.time - timer;
		if(tube.fillAmount < 1.0f){
			tube.fillAmount = elapsed / fillDuration;
		}
		if(tube.fillAmount >= 1.0f){
			filling = 0;
			filled++;
		}
	}

	
}
