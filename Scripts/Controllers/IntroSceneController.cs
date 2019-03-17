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

		//buttonObj.SetActive(true);
		//handModels.SetActive(true);
		//leapMotion.SetActive(true);

		StartCoroutine("Intro");
	}

	IEnumerator Intro() {
		// Time to start
		yield return new WaitForSeconds(3);
		textObj.SetActive(true);
		textPanel.SetActive(true);
		text.text = "Hello! Welcome to THE COMPLEX.";
		yield return new WaitForSeconds(3);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "There are 6 levels in total for you to complete";
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "In a short while you will be sent to a room known as the Main Menu where you will be faced with multiple doors";
		yield return new WaitForSeconds(8);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "It is said that within the left door there are 2 challenges focusing on the movement of objects and complex mechanisms...";
		yield return new WaitForSeconds(8);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "... and that within the right door there are 2 rooms full of complicated puzzles that test your memory and wit";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "As for the last 2 rooms...";
		yield return new WaitForSeconds(3.5f);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "...nobody has been able to find them yet";
		yield return new WaitForSeconds(3.5f);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "But there is a rumor that the challenges within them are combinations of the previous rooms";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "In order to tackle these rooms, you have a special finger tracking device before you";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "This device is known as the LEAP Motion Controller";
		yield return new WaitForSeconds(5);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "This device can track both of your hands and allow you to interact with THE COMPLEX";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "It is not perfect, so please be patient with it";
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "Also make sure any actions you perform can be seen clearly by the device";
		yield return new WaitForSeconds(5);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.color = Color.green;
		text.text = "Hand tracking is now enabled";
		leapMotion.SetActive(true);
		handModels.SetActive(true);
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.color = Color.white;
		text.text = "Feel free to move your hand around to get a feel for the Leap Motion's capabilities";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.5f);
		text.text = "When you have finished simply point at the button in front of you to continue";
		buttonObj.SetActive(true);
		yield return new WaitForSeconds(6);
		text.text = "";
		textObj.SetActive(false);
		textPanel.SetActive(false);
		yield return null;
	}
}
