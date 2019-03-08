using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1BNavigationManager : MonoBehaviour {

	public UpDownNavigation vertNavigation;
	public LeftRightNavigation horzNavigation;
	public GameObject upIndicator, downIndicator, rightIndicator, leftIndicator;
	public AbstractRController controller;
	private int indicatorState = 0; // 0 - up/left/right, 1 - left/right, 2 - down
	private int previousState = 0;

	// Use this for initialization
	void Start () {
		horzNavigation.activate();
		vertNavigation.deactivate();
		upIndicator.SetActive(false);
		downIndicator.SetActive(false);
		leftIndicator.SetActive(true);
		rightIndicator.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(vertNavigation.isFacingUp()){
			indicatorState = 2;
		} else {
			if(horzNavigation.facing == 2){
				indicatorState = 0;
			} else {
				indicatorState = 1;
			}
		}
		if(previousState != indicatorState){
			if(indicatorState == 0){
				if(controller.isActivated()){
					upIndicator.SetActive(true);
					vertNavigation.activate();
				} else {
					upIndicator.SetActive(false);
					vertNavigation.deactivate();
				}
				downIndicator.SetActive(false);
				leftIndicator.SetActive(true);
				rightIndicator.SetActive(true);
				
				horzNavigation.activate();
			} else if(indicatorState == 1){
				upIndicator.SetActive(false);
				downIndicator.SetActive(false);
				leftIndicator.SetActive(true);
				rightIndicator.SetActive(true);
				vertNavigation.deactivate();
			} else if(indicatorState == 2){
				upIndicator.SetActive(false);
				downIndicator.SetActive(true);
				leftIndicator.SetActive(false);
				rightIndicator.SetActive(false);
				horzNavigation.deactivate();
			}
		}
		previousState = indicatorState;
		
	}

	
}
