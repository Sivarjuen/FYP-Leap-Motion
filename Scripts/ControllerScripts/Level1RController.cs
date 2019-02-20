using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1RController : MonoBehaviour {

	public ArmController arm;
	public CraneController crane;
	public PowerPuzzle puzzle;
	private bool activated = false;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!activated){
			if(puzzle.isCompleted()){
				activate();
				activated = true;
			}
		}
	}

	private void activate(){
		arm.activate();
		crane.activate();
	}
}
