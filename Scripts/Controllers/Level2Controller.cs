using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour {

	private bool levelCompleted = false; // Completion state of entire level

	[Header("Level 2-1 Attributes")]
	public bool firstLevel = true;
	public Puzzle colourPuzzle;
	public Puzzle shapePuzzle;
	public PowerPuzzle powerPuzzle;
	private bool cpCompleted = false, spCompleted = false, ppCompleted = false; // Completion state of each of the 3 puzzles
	public GameObject colourLight, shapeLight, powerLight;
	public GameObject miniLightLeft, miniLightMiddle, miniLightRight;
	public Material[] materials;
	private Renderer colourLightRend, shapeLightRend, powerLightRend;
	private Renderer leftMiniRend, middleMiniRend, rightMiniRend;
	private int[] lightSolution;
	private int[] solutionState;

	[Header("Level 2-2 Attributes")]
	public bool secondLevel = false;
	
	// Use this for initialization
	void Start () {
		if(firstLevel){
			initialiseSolutions();
			colourLightRend = colourLight.GetComponent<Renderer>();
			shapeLightRend = shapeLight.GetComponent<Renderer>();
			powerLightRend = powerLight.GetComponent<Renderer>();
			leftMiniRend = miniLightLeft.GetComponent<Renderer>();
			middleMiniRend = miniLightMiddle.GetComponent<Renderer>();
			rightMiniRend = miniLightRight.GetComponent<Renderer>();
		} else if(secondLevel){

		}
	}
	
	// Update is called once per frame
	void Update () {
		string s = "";
		string a = "";
		s += lightSolution[0];
		s += lightSolution[1];
		s += lightSolution[2];
		a += solutionState[0];
		a += solutionState[1];
		a += solutionState[2];
		Debug.Log("Solution: " + s);
		Debug.Log("My answer: " + a);
		if(!levelCompleted){
			if(firstLevel){
				if(!cpCompleted && colourPuzzle.isCompleted()) {
					cpCompleted = true;
					turnLightOn(1);
				}
				if(!spCompleted && shapePuzzle.isCompleted()) {
					spCompleted = true;
					turnLightOn(2);
				}
				if(!ppCompleted && powerPuzzle.isCompleted()) {
					ppCompleted = true;
					turnLightOn(3);
				}
			} else if(secondLevel){

			}
		} else{
			Debug.Log("COMPLETE");
		}
	}

	private void initialiseSolutions(){	// Index 0 - colour, Index 1 - shape, Index 2 - power
		lightSolution = new int[3];
		solutionState = new int[3];
		solutionState[0] = -1;
		solutionState[1] = -1;
		solutionState[2] = -1;
		lightSolution[0] = Random.Range(0, 5); // Generate a number between 0-4 inclusive
		lightSolution[1] = Random.Range(0, 5);
		lightSolution[2] = Random.Range(0, 5);
		while(lightSolution[1] == lightSolution[0]) lightSolution[1] = Random.Range(0, 5);
		while(lightSolution[2] == lightSolution[1] || lightSolution[2] == lightSolution[0] ) lightSolution[2] = Random.Range(0, 5);
	}

	private void turnLightOn(int index){
		switch(index){
			case 1:
				colourLightRend.material = materials[lightSolution[0]];
				break;
			case 2:
				shapeLightRend.material = materials[lightSolution[1]];
				break;
			case 3:
				powerLightRend.material = materials[lightSolution[2]];
				break;
			default:
				Debug.LogError("Invalid Light Index");
				break;
		}
	}

	public void toggleMiniLights(int index){
		switch(index){
			case 1:
				int temp1 = solutionState[0] + 1;
				if(temp1 > 4) temp1 = 0;
				solutionState[0] = temp1;
		
				leftMiniRend.material = materials[solutionState[0]];
				break;
			case 2:
				int temp11 = solutionState[0] + 1;
				int temp22 = solutionState[1] + 1;
				int temp33 = solutionState[2] + 1;
				if(temp11 > 4) temp11 = 0;
				if(temp22 > 4) temp22 = 0;
				if(temp33 > 4) temp33 = 0;
				solutionState[0] = temp11;
				solutionState[1] = temp22;
				solutionState[2] = temp33;

				leftMiniRend.material = materials[solutionState[0]];
				middleMiniRend.material = materials[solutionState[2]];
				rightMiniRend.material = materials[solutionState[1]];
				break;
			case 3:
				int temp3 = solutionState[1] + 1;
				if(temp3 > 4) temp3 = 0;
				solutionState[1] = temp3;

				rightMiniRend.material = materials[solutionState[1]];
				break;
			default:
				Debug.LogError("Invalid Light Index");
				break;
		}
		checkSolution();
	}

	private void checkSolution(){
		if(firstLevel){
			if(cpCompleted && spCompleted && ppCompleted){
				int remaining = 3;
				for(int i = 0; i < 3; i++){
					if(lightSolution[i] == solutionState[i]) remaining--;
				}
				if(remaining == 0){
					levelCompleted = true;
				}
			}
		}
	}
}
