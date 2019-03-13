using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCustomiser : AbstractHolder {

	public void onButtonPressed(){
		if(containsBall && ball != null){
			ball.changeColour();
		}
	}

	override protected void updateValue(){
		//do nothing
	}
}
