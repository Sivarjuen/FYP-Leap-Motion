using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ANavigationManager : MonoBehaviour {

	public UpDownNavigation vertNavigation;
	public LeftRightNavigation horzNavigation;
	public GameObject upIndicator, downIndicator, rightIndicator, leftIndicator;
	private int indicatorState = 0; // 0 - right, 1 - left

	// Use this for initialization
	void Start () {
		horzNavigation.activate();
		vertNavigation.activate();
		upIndicator.SetActive(false);
		downIndicator.SetActive(true);
		leftIndicator.SetActive(false);
		rightIndicator.SetActive(true);
		horzNavigation.lockLeftMovement(true);
		horzNavigation.lockRightMovement(false);
	}
	
	// Update is called once per frame
	void Update () {		
		if(!vertNavigation.isFacingUp()){
			horzNavigation.deactivate();
			downIndicator.SetActive(false);
			upIndicator.SetActive(true);
			leftIndicator.SetActive(false);
			rightIndicator.SetActive(false);
		} else {
			if(horzNavigation.facing == 0){
				indicatorState = 0;
			} else if(horzNavigation.facing == 1) {
				indicatorState = 1;
			} else {
				Debug.LogError("Facing in an invalid direction!");
			}

			horzNavigation.activate();
			upIndicator.SetActive(false);
			downIndicator.SetActive(true);
			if(indicatorState == 0){
				horzNavigation.lockLeftMovement(true);
				horzNavigation.lockRightMovement(false);
				leftIndicator.SetActive(false);
				rightIndicator.SetActive(true);
			} else if(indicatorState == 1){
				horzNavigation.lockLeftMovement(false);
				horzNavigation.lockRightMovement(true);
				leftIndicator.SetActive(true);
				rightIndicator.SetActive(false);
			}
		}
	}

	
}
