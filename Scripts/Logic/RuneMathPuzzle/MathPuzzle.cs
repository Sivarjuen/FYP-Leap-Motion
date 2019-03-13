using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathPuzzle : MonoBehaviour {

	public int puzzleNumber; //starting from 1
	public MathSolution solution;
	private bool completed;
	private bool active = false;

	// Use this for initialization
	void Start () {
		completed = false;
	}

	public void notifyPuzzle(){
		if(active && !completed){
			completed = solution.checkSolution(puzzleNumber);
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
	}
}
