using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathSolution : MonoBehaviour {
	
	public int[] solutions;
	public int red = 0, blue = 0, purple = 0, green = 0, yellow = 0;
	private int[] values;
	private int finished = 0;
	private bool completed;
	public MathPuzzle[] puzzles;
	public MathBallHolder[] solution;
	//1 = Red, 2 = Blue, 3 = Purple, 4 = Green, 5 = Yellow

	void Start() {
		completed = false;
		values = new int[]{red, blue, purple, green, yellow};
		puzzles[0].activate();
	}

	void Update(){
		if(!completed){
			if(puzzles[finished].isCompleted()){
				finished++;
				if(finished == puzzles.Length){
					completed = true;
				} else {
					puzzles[finished].activate();
				}
			}
		}
	}

	public int getValue(int i){
		return values[i-1];
	}

	public bool checkSolution(int puzzleNumber){
		int left = 0, right = 0;
		for(int i = 0; i < solution.Length; i++){
			if(i < 9){
				left += solution[i].getValue();
			} else {
				right += solution[i].getValue();
			}
		}
		if(left != right) return false;
		return left == solutions[puzzleNumber+1];

	}

	public void notifyPuzzles(){
		if(!completed){
			puzzles[finished].activate();
		}
	}

	public bool isCompleted(){
		return completed;
	}
}
