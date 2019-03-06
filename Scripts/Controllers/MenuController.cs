using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : AbstractController {

	public GameObject leftSliderObj, rightSliderObj, scoreSliderObj, optionsSliderObj, exitSliderObj;
	private Slider leftSlider, rightSlider, scoreSlider, optionsSlider, exitSlider;

	override protected void initialiseSlidersAndDicts(){
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

	override protected void updateSliders(){
		if(hovering){
			if(dict[activeSlider].value < 1.0f){
				float elapsed = Time.time - timer;
				dict[activeSlider].value = elapsed / hoverDuration;
			} else {
				if(activeSlider.Equals("leftSlider")){
					SceneManager.LoadScene(2);
					//StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.Out, 1));
				}
			}
		} else {
			foreach(Slider slider in dict.Values){
				slider.value = 0.0f;
				deactivateSliders();
			}
		}
	}


}
