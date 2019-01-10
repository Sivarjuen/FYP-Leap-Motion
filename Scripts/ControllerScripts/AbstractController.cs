using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractController : MonoBehaviour {

	protected bool hovering = false;
	protected float hoverDuration = 1.0f;
	protected float timer = 0.0f;
	protected Dictionary<string, Slider> dict;
	protected Dictionary<Slider, GameObject> dict2;
	protected string activeSlider = "";

	// Use this for initialization
	void Start () {
		initialiseSlidersAndDicts();
		deactivateSliders();
	}
	
	// Update is called once per frame
	void Update () {
		updateSliders();
	}

	public void startedHovering(string sliderName){
		if(!hovering){
			if(sliderName.Equals("exitSlider")){
				hoverDuration = 2.0f;
			} else {
				hoverDuration = 1.0f;
			}
			activeSlider = sliderName;
			hovering = true;
			timer = Time.time;
			dict2[dict[sliderName]].SetActive(true);
		}
	}

	protected void deactivateSliders(){
		foreach(GameObject obj in dict2.Values){
			obj.SetActive(false);
		}
	}

	protected abstract void initialiseSlidersAndDicts();

	protected abstract void updateSliders();

	public void stoppedHovering(){
		hovering = false;
		activeSlider = "";
	}
}
