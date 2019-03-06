using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2NavigationManager : MonoBehaviour {

	public UpDownNavigation vertNavigation;
	public LeftRightNavigation horzNavigation;
	public GameObject upIndicator, downIndicator, rightIndicator, leftIndicator;
	private int indicatorState = 0; // 0 - down/left/right, 1 - up, 2 - left/right

	// Use this for initialization
	void Start () {
		horzNavigation.activate();
		vertNavigation.activate();
		upIndicator.SetActive(false);
		downIndicator.SetActive(true);
		leftIndicator.SetActive(true);
		rightIndicator.SetActive(true);
		horzNavigation.lockLeftMovement(false);
		horzNavigation.lockRightMovement(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!vertNavigation.isFacingUp()){
			indicatorState = 1;
		} else {
			if(horzNavigation.facing == 0){
				indicatorState = 0;
			} else {
				indicatorState = 2;
			}
		}
		if(indicatorState == 0){
			horzNavigation.activate();
			vertNavigation.activate();
			downIndicator.SetActive(true);
			upIndicator.SetActive(false);
			leftIndicator.SetActive(true);
			rightIndicator.SetActive(true);
		} else if(indicatorState == 1){
			horzNavigation.deactivate();
			vertNavigation.activate();
			upIndicator.SetActive(true);
			downIndicator.SetActive(false);
			leftIndicator.SetActive(false);
			rightIndicator.SetActive(false);
		} else if(indicatorState == 2){
			horzNavigation.activate();
			vertNavigation.deactivate();
			upIndicator.SetActive(false);
			downIndicator.SetActive(false);
			leftIndicator.SetActive(true);
			rightIndicator.SetActive(true);
		}		
	}

	
}
