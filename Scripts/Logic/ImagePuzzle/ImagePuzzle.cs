using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePuzzle : MonoBehaviour {

	private bool completed;
	public ImageTile[] center, left, right;
	private int[] original, leftSolution, rightSolution;
	public Renderer light;
	
	// Use this for initialization
	void Start () {
		completed = false;
		original = new int[9];
		leftSolution = new int[9];
		rightSolution = new int[9];
		initialiseTiles();
		initialiseSolutions();
	}
	
	// Update is called once per frame
	void Update () {
		if(!completed){
			checkSolution();
		}
	}

	public bool isCompleted(){
		return completed;
	}

	private void initialiseTiles(){
		List<int> indices = new List<int>(){0,1,2,3,4,5,6,7,8};
		for(int i = 1; i <= 4; i++){
			for(int j = 0; j <= 1; j++){
				int index = Random.Range(0, indices.Count);
				center[indices[index]].setColour(i);
				left[indices[index]].setColour(i);
				right[indices[index]].setColour(i);
				original[indices[index]] = i;
				indices.RemoveAt(index);
			}
		}
		int colour = Random.Range(1, 5);
		center[indices[0]].setColour(colour);
		left[indices[0]].setColour(colour);
		right[indices[0]].setColour(colour);
		original[indices[0]] = colour;
	}

	private void initialiseSolutions(){
		leftSolution[0] = original[2];
		leftSolution[1] = original[5];
		leftSolution[2] = original[8];
		leftSolution[3] = original[1];
		leftSolution[4] = original[4];
		leftSolution[5] = original[7];
		leftSolution[6] = original[0];
		leftSolution[7] = original[3];
		leftSolution[8] = original[6];

		rightSolution[0] = original[6];
		rightSolution[1] = original[3];
		rightSolution[2] = original[0];
		rightSolution[3] = original[7];
		rightSolution[4] = original[4];
		rightSolution[5] = original[1];
		rightSolution[6] = original[8];
		rightSolution[7] = original[5];
		rightSolution[8] = original[2];
	}

	private void checkSolution(){
		int correct = 0; // 9 = complete
		for(int i = 0; i < 9; i++){
			//Debug.Log("Index: " + i + " - Left: " + left[i].getColour() + "-" + leftSolution[i] + " - Right:" + right[i].getColour() + "-" + rightSolution[i]);
			if(left[i].getColour() == leftSolution[i] && right[i].getColour() == rightSolution[i]){
				correct++;
			}
		}
		if(correct == 9){
			completed = true;
			light.material.color = Color.green;
		}
	}
}
