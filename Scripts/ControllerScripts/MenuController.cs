using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public GameObject leftSliderObj, rightSliderObj, scoreSliderObj, optionsSliderObj, exitSliderObj;
	private Slider leftSlider, rightSlider, scoreSlider, optionsSlider, exitSlider;
	private bool hovering = false;
	private float hoverDuration = 1.0f;
	private float timer = 0.0f;
	private Dictionary<string, Slider> dict;
	private Dictionary<Slider, GameObject> dict2;
	private string activeSlider = "";
	
	void Awake() {
		deactivateSliders();
	}
	
	// Use this for initialization
	void Start () {
		initialiseSlidersAndDicts();
	}
	
	// Update is called once per frame
	void Update () {
		updateSliders();
	}

	public void stoppedHovering(){
		hovering = false;
		activeSlider = "";
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

	private void deactivateSliders(){
		leftSliderObj.SetActive(false);
		rightSliderObj.SetActive(false);
		scoreSliderObj.SetActive(false); 
		optionsSliderObj.SetActive(false); 
		exitSliderObj.SetActive(false);
	}

	private void initialiseSlidersAndDicts(){
		dict = new Dictionary<string, Slider>();
		dict2 = new Dictionary<Slider, GameObject>();

		leftSlider = leftSliderObj.GetComponent<Slider>();
		rightSlider = rightSliderObj.GetComponent<Slider>();
		scoreSlider = scoreSliderObj.GetComponent<Slider>();
		optionsSlider = optionsSliderObj.GetComponent<Slider>();
		exitSlider = exitSliderObj.GetComponent<Slider>();

		dict.Add("leftSlider", leftSlider);
		dict.Add("rightSlider", rightSlider);
		dict.Add("scoreSlider", scoreSlider);
		dict.Add("optionsSlider", optionsSlider);
		dict.Add("exitSlider", exitSlider);

		dict2.Add(leftSlider, leftSliderObj);
		dict2.Add(rightSlider, rightSliderObj);
		dict2.Add(scoreSlider, scoreSliderObj);
		dict2.Add(optionsSlider, optionsSliderObj);
		dict2.Add(exitSlider, exitSliderObj);
	}

	private void updateSliders(){
		if(hovering){
			if(dict[activeSlider].value < 1.0f){
				float elapsed = Time.time - timer;
				dict[activeSlider].value = elapsed / hoverDuration;
			} else {
				//TODO do something
			}
		} else {
			foreach(Slider slider in dict.Values){
				slider.value = 0.0f;
				deactivateSliders();
			}
		}
	}


}
