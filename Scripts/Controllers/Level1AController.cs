using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1AController : AbstractLController {

	public Image tube1, tube2, tube3, tube4, door;
	public GameObject runes, emptyRunes, runeBalls;
	private bool objectPuzzleCompleted = false, fillingDoor = false;
	public ObjectHolder holder1, holder2, holder3, holder4;
	private static float doorFillDuration = 5.0f;

	override protected void initialiseTubes(){
		tube1.fillAmount = 0.0f;
		tube2.fillAmount = 0.0f;
		tube3.fillAmount = 0.0f;
		tube4.fillAmount = 0.0f;
		tubes = 4;
		door.fillAmount = 0.0f;
	}

	override protected void updateTubes(){
		switch(filling){
			case 1:
				fillTube(tube1);
				break;
			case 2:
				fillTube(tube2);
				break;
			case 3:
				fillTube(tube3);
				break;
			case 4:
				fillTube(tube4);
				break;
		}
	}

	override protected void checkLevelSpecificCriteria(){
		if(!objectPuzzleCompleted){
			if(holder1.isLocked() && holder2.isLocked() && holder3.isLocked() && holder4.isLocked()){
				objectPuzzleCompleted = true;
				emptyRunes.SetActive(false);
				runes.SetActive(true);
				runeBalls.SetActive(true);
			}
		}
		if(complete){
			if(!fillingDoor){
				timer = Time.time;
				fillingDoor = true;
			}
			processCompletion();
		}
	}

	private void processCompletion(){
		float elapsed = Time.time - timer;
		if(door.fillAmount < 1.0f){
			door.fillAmount = elapsed / doorFillDuration;
		}
		if(door.fillAmount >= 1.0f){
			SceneManager.LoadScene(5);
		}
	}
}
