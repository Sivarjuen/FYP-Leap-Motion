using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanMathPuzzle : MonoBehaviour {

	private const int answer = 78;
	private bool completed;
	private int left = -1;
	private int right = -1;
	public GameObject light1, light2;

	// Use this for initialization
	void Start () {
		completed = false;
	}

	public bool isCompleted(){
		return completed;
	}

	public void updateLeft(int i){
		left = i;
		checkSolution();
	}

	public void updateRight(int i){
		right = i;
		checkSolution();
	}

	private void checkSolution(){
		if(!completed){
			if(left >= 0 && right >= 0){
				if(left+right == answer){
					completed = true;
					light1.GetComponent<Renderer>().material.color = Color.green;
					light2.GetComponent<Renderer>().material.color = Color.green;
				}
			}
		}
	}



}
