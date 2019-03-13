using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathBallHolder : AbstractHolder {

	public bool left = true;
	public MathSolution solution;
	private int value = 0;

	public int getValue(){
		return value;
	}

	override protected void updateValue(){
		if(containsBall && ball != null){
			value = solution.determineValue(ball.getColour(), left);
			solution.notifyPuzzles();
		}
	}
}
