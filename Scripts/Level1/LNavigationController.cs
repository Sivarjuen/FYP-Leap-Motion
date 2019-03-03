using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LNavigationController : MonoBehaviour {

	public UpDownNavigation vertNavigation;
	public LeftRightNavigation horzNavigation;
	public GameObject upIndicator, downIndicator, rightIndicator, leftIndicator;
	private int indicatorState = 0; // 0 - down/left/right, 1 - up, 2 - left, 3 - right

	// Use this for initialization
	void Start () {
		horzNavigation.activate();
		vertNavigation.activate();
		upIndicator.SetActive(false);
		downIndicator.SetActive(true);
		leftIndicator.SetActive(true);
		rightIndicator.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(!vertNavigation.isFacingUp()){
			indicatorState = 1;
		} else {
			if(horzNavigation.facing == 0){
				indicatorState = 0;
			} else if(horzNavigation.facing == 1){
				indicatorState = 2;
			} else {
				indicatorState = 3;
			}
		}
		if(indicatorState == 0){
			horzNavigation.activate();
			vertNavigation.activate();
			horzNavigation.lockLeftMovement(false);
			horzNavigation.lockRightMovement(false);
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
			upIndicator.SetActive(false);
			downIndicator.SetActive(false);
			leftIndicator.SetActive(true);
			rightIndicator.SetActive(false);
			horzNavigation.activate();
			vertNavigation.deactivate();
			horzNavigation.lockLeftMovement(false);
			horzNavigation.lockRightMovement(true);
		} else if(indicatorState == 3){
			upIndicator.SetActive(false);
			downIndicator.SetActive(false);
			leftIndicator.SetActive(false);
			rightIndicator.SetActive(true);
			horzNavigation.activate();
			vertNavigation.deactivate();
			horzNavigation.lockLeftMovement(true);
			horzNavigation.lockRightMovement(false);
		}		
	}

	
}
