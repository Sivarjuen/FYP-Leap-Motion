using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePuzzle : Puzzle {

	override protected int getData(PuzzleButton b){
		return b.shape;
	}
}
