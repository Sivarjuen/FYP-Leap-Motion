using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathPuzzle : MonoBehaviour {

	public int puzzleNumber; //starting from 1
	public MathSolution solution;
	private bool completed;
	private bool active = false;
	public Image highlight;
	public GameObject gameObject;

	void Awake() {
		completed = false;
		gameObject.SetActive(false);
	}

	public void notifyPuzzle(){
		if(active && !completed){
			completed = solution.checkSolution(puzzleNumber);
			if(completed){
				highlight.color = Color.green;
			}
		}
	}

	public bool isActive(){
		return active;
	}
	
	public bool isCompleted(){
		return completed;
	}

	public void activate(){
		active = true;
		gameObject.SetActive(true);
	}

	public void manuallyComplete(){
		completed = true;
		highlight.color = Color.green;
	}
}
