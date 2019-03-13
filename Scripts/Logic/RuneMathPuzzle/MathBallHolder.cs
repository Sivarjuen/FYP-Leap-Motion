using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathBallHolder : AbstractHolder {

	public int id;
	public MathSolution solution;
	private int value = 0;

	public int getValue(){
		return value;
	}

	override protected void updateValue(){
		if(containsBall && ball != null){
			value = solution.getValue(ball.getColour());
			solution.notifyPuzzles();
		}
	}
}
