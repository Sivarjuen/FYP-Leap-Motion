using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customiser : Holder {

	override protected void setRuneBall(RuneBall ball){
		this.ball = ball;
		containsBall = true;
	}

	public void onColourButtonPressed(){
		if(containsBall && ball != null){
			ball.changeColour();
		}
	}

	public void onNumberButtonPressed(){
		if(containsBall && ball != null){
			ball.changeNumber();
		}
	}
}
