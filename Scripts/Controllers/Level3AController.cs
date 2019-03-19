using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3AController : MonoBehaviour {

	public Image door;
	private static float doorFillDuration = 5.0f;
	private float timer = 0.0f;
	private bool fillingDoor = false;
	public LeftRightNavigation horz_navigation;
	public UpDownNavigation navigation;
	public RomanMathPuzzle romanMathPuzzle;
	public MathSolution puzzles;
	private bool puzzlesActivated = false;
	
	// Update is called once per frame
	void Update () {
		if(!puzzlesActivated){
			if(romanMathPuzzle.isCompleted()){
				puzzles.activate();
				puzzlesActivated = true;
			}
		} else {
			if(Input.GetKeyDown(KeyCode.M)){
				puzzles.manuallyComplete();
			}
			if(puzzles.isCompleted()){
				navigation.activate();
				navigation.moveCameraUpandLock();
				horz_navigation.deactivate();
				if(!fillingDoor){
					timer = Time.time;
					fillingDoor = true;
				}
				processCompletion();
			}
		}
	}

	private void processCompletion(){
		float elapsed = Time.time - timer;
		if(door.fillAmount < 1.0f){
			door.fillAmount = elapsed / doorFillDuration;
		}
		if(door.fillAmount >= 1.0f){
			SceneManager.LoadScene(9);
		}
	}
}
