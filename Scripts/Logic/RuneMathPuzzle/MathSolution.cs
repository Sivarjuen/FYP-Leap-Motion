using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathSolution : MonoBehaviour {
	
	public int[] solutions;
	public int red = 0, blue = 0, purple = 0, green = 0;
	public int red2 = 0, blue2 = 0, purple2 = 0, green2 = 0;
	private int[] values;
	private int finished = 0;
	private bool completed;
	public MathPuzzle[] puzzles;
	public MathBallHolder[] solution;
	//1 = Red, 2 = Blue, 3 = Purple, 4 = Green

	void Start() {
		completed = false;
		values = new int[]{red, blue, purple, green};
		puzzles[0].activate();
	}

	void Update(){
		if(!completed){
			if(puzzles[finished].isCompleted()){
				finished++;
				if(finished == puzzles.Length){
					completed = true;
				} else {
					if(finished == 3){
						values = new int[]{red2, blue2, purple2, green2};
					}
					puzzles[finished].activate();
				}
			}
		}
	}

	public int determineValue(int i, bool left){
		//1 = Red, 2 = Blue, 3 = Purple, 4 = Green
		switch(finished){
			case 0: //First puzzle
				if(left){ // R
					if(i == 1) return getNumber(i);
				} else { // B
					if(i == 2) return getNumber(i);
				}
				break;
			case 1: //Second puzzle
				if(left){ // B
					if(i == 2) return getNumber(i);
				} else { // P
					if(i == 3) return getNumber(i);
				}
				break;
			case 2: //Third puzzle
				if(left){ // R, B, G
					if(i == 1 || i == 2 || i == 4) return getNumber(i);
				} else { // R, B, P
					if(i == 1 || i == 2 || i == 3) return getNumber(i);
				}
				break;
			case 3: //Fourth puzzle
				if(left){  // R, G
					if(i == 1 || i == 4) return getNumber(i);
				} else { // B
					if(i == 2) return getNumber(i);
				}
				break;
			case 4: //Fifth puzzle
				if(left){ // P, R
					if(i == 1 || i == 3) return getNumber(i);
				} else { // R, G
					if(i == 1 || i == 4) return getNumber(i);
				}
				break;
			case 5: //Sixth puzzle
				if(left){ // B, P, R
					if(i == 1 || i == 2 || i == 3) return getNumber(i);
				} else { // G, R
					if(i == 1 || i == 4) return getNumber(i);
				}
				break;
			default:
				return 0;
			
		}
		return 0;
	}

	private int getNumber(int i){
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
		return left == solutions[puzzleNumber-1];

	}

	public void notifyPuzzles(){
		if(!completed){
			puzzles[finished].notifyPuzzle();
		}
	}

	public bool isCompleted(){
		return completed;
	}
}
