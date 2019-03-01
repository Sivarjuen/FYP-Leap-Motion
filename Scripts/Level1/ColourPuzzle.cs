using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPuzzle : Puzzle {

	override protected int getData(PuzzleButton b){
		return b.color;
	}
}
