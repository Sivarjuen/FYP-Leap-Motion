using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroSceneController : AbstractController {

	private TextMeshProUGUI text;
	public GameObject textObj, textPanel, handModels, leapMotion, buttonObj, continueSliderObj;
	private Slider continueSlider;

	override protected void initialiseSlidersAndDicts(){
		dict = new Dictionary<string, Slider>();
		dict2 = new Dictionary<Slider, GameObject>();

		continueSlider = continueSliderObj.GetComponent<Slider>();
		dict.Add("continueSlider", continueSlider);
		dict2.Add(continueSlider, continueSliderObj);
	}

	override protected void updateSliders(){
		if(hovering){
			if(dict[activeSlider].value < 1.0f){
				float elapsed = Time.time - timer;
				dict[activeSlider].value = elapsed / hoverDuration;
			} else {
				// SceneManager.LoadScene(1);
				// StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.Out, 1));
			}
		} else {
			foreach(Slider slider in dict.Values){
				slider.value = 0.0f;
				deactivateSliders();
			}
		}
	}

	private void Awake() {
		//Get GameObjects
		textObj = GameObject.Find("IntroText");
		textPanel = GameObject.Find("TextPanel");

        text = textObj.GetComponent<TextMeshProUGUI>();

		textObj.SetActive(false);
		textPanel.SetActive(false);
		buttonObj.SetActive(false);
		handModels.SetActive(false);
		leapMotion.SetActive(false);	
		StartCoroutine("Intro");
	}

	IEnumerator Intro() {
		// Time to start
		yield return new WaitForSeconds(3);
		textObj.SetActive(true);
		textPanel.SetActive(true);
		text.text = "Welcome";
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Hand tracking will be enabled shortly";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Remember that the LEAP Motion Controller can only track what it sees";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "So make sure any actions you perform can be seen clearly by the device";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.color = Color.green;
		text.text = "Hand tracking is now enabled";
		leapMotion.SetActive(true);
		handModels.SetActive(true);
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.color = Color.white;
		text.text = "Feel free to move your hand around to get a feel for the Leap Motion's capabilities";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "When you have finished point towards the 'Continue' button with one of your index fingers to move on to the next stage";
		buttonObj.SetActive(true);
		yield return new WaitForSeconds(7);
		text.text = "";
		textObj.SetActive(false);
		textPanel.SetActive(false);
		yield return null;
	}
}
