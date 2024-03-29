﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : AbstractController {

	public GameObject leftSliderObj, rightSliderObj, scoreSliderObj, optionsSliderObj, exitSliderObj;
	private Slider leftSlider, rightSlider, scoreSlider, optionsSlider, exitSlider;
	public GameObject leftText, leftLock, leftTick, rightText, rightLock, rightTick;
	public GameObject leftLight, rightLight;
	public GameObject handModels, leapMotion, middleDoor, centerMenu, targetPosition;
	public bool debug = true;
	public int startState = 0;
	private bool animateDoor = false;
	private Quaternion targetRotation;
	public Image door;
	private static float doorFillDuration = 5.0f;
	private float doorTimer = 0.0f;
	private bool fillingDoor = false;
	public TextMeshProUGUI text;

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

		if(debug) GameController.State = startState;

		// State machine to handle progression
		if(GameController.State == GameController.START){
			leftText.SetActive(false);
			leftLock.SetActive(true);
			leftTick.SetActive(false);
			rightText.SetActive(false);
			rightLock.SetActive(true);
			rightTick.SetActive(false);
		} else if (GameController.State == GameController.AFTER_TUTORIAL){
			leftText.SetActive(true);
			leftLock.SetActive(false);
			leftTick.SetActive(false);
			rightText.SetActive(false);
			rightLock.SetActive(true);
			rightTick.SetActive(false);
		} else if (GameController.State == GameController.LEFT_FINISHED){
			leftText.SetActive(false);
			leftLock.SetActive(false);
			leftTick.SetActive(true);
			rightText.SetActive(true);
			rightLock.SetActive(false);
			rightTick.SetActive(false);
			leftLight.GetComponent<Renderer>().material.color = Color.green;
		} else if (GameController.State == GameController.RIGHT_FINISHED){
			leftText.SetActive(false);
			leftLock.SetActive(false);
			leftTick.SetActive(true);
			rightText.SetActive(false);
			rightLock.SetActive(false);
			rightTick.SetActive(true);
			rightLight.GetComponent<Renderer>().material.color = Color.green;
			leftLight.GetComponent<Renderer>().material.color = Color.green;
			targetRotation = middleDoor.transform.rotation * Quaternion.Euler(0, 0, 180);
			StartCoroutine("UnlockMiddleDoor");
		} else if (GameController.State == GameController.END){
			leftText.SetActive(false);
			leftLock.SetActive(false);
			leftTick.SetActive(true);
			rightText.SetActive(false);
			rightLock.SetActive(false);
			rightTick.SetActive(true);
			leftLight.GetComponent<Renderer>().material.color = Color.green;
			rightLight.GetComponent<Renderer>().material.color = Color.green;
			text.text = "You have beaten \n THE COMPLEX";
		}
	}

	IEnumerator UnlockMiddleDoor() {
		handModels.SetActive(false);
		leapMotion.SetActive(false);
		centerMenu.SetActive(false);
		yield return new WaitForSeconds(1);
		animateDoor = true;
		yield return new WaitForSeconds(10);
		doorTimer = Time.time;
		fillingDoor = true;
		yield return null;
	}

	override protected void updateSliders(){
		if(hovering){
			if(dict[activeSlider].value < 1.0f){
				float elapsed = Time.time - timer;
				dict[activeSlider].value = elapsed / hoverDuration;
			} else {
				if(activeSlider.Equals("scoreSlider")){
					SceneManager.LoadScene(2);
				}
				if(activeSlider.Equals("leftSlider")){
					SceneManager.LoadScene(4);
				}
				if(activeSlider.Equals("rightSlider")){
					SceneManager.LoadScene(6);
				}
			}
		} else {
			foreach(Slider slider in dict.Values){
				slider.value = 0.0f;
				deactivateSliders();
			}
		}
		if(animateDoor){
			middleDoor.transform.position = Vector3.Lerp(middleDoor.transform.position, targetPosition.transform.position, 1.0f * Time.deltaTime);
			middleDoor.transform.rotation = Quaternion.Lerp(middleDoor.transform.rotation, targetRotation, .5f * Time.deltaTime);
		}

		if(fillingDoor){
			float elapsed = Time.time - doorTimer;
			if(door.fillAmount < 1.0f){
				door.fillAmount = elapsed / doorFillDuration;
			}
			if(door.fillAmount >= 1.0f){
				SceneManager.LoadScene(8);
			}
		}
	}


}
