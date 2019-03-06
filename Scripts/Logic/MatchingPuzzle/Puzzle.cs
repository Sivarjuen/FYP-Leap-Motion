using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour {

	public PuzzleButton[] buttons;
	protected bool completed;
	protected bool toggled = false;
	protected int matched = 0;
	private PuzzleButton toggledButton;

	
	void Start () {
		completed = false;
	}
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			completed = true;
		}
		//int matchedTiles = 0;
		//foreach(PuzzleButton b in buttons){
		//	if(b.isMatched()) matchedTiles++;
		//}
	}

	public bool isCompleted(){
		return completed;
	}

	public void toggleReceived(PuzzleButton b){
		if(!toggled){
			toggled = true;
			toggledButton = b;
		} else {
			if(getData(toggledButton) == getData(b) && toggledButton.id != b.id){
				matched++;
				toggledButton.setMatched();
				b.setMatched();
				if(matched == 8) completed = true;
			} else {
				toggledButton.autoToggle();
				b.autoToggle();
			}
			toggled = false;
			toggledButton = null;
		}
	}

	protected abstract int getData(PuzzleButton b);
}
