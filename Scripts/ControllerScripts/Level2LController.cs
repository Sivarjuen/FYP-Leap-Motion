using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1LController : AbstractLController {

	public Image tube1, tube2, tube3, tube4;
	public GameObject upIndicator, downIndicator;

	override protected void initialiseTubes(){
		tube1.fillAmount = 0.0f;
		tube2.fillAmount = 0.0f;
		tube3.fillAmount = 0.0f;
		tube4.fillAmount = 0.0f;
		tubes = 4;
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

	override protected void updateIndicators(){
		upIndicator.SetActive(!navigation.isFacingUp());
		downIndicator.SetActive(navigation.isFacingUp());
	}
}
