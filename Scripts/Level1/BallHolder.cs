using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : Holder {

	public int id = 0;

	override protected void setRuneBall(RuneBall ball){
		this.ball = ball;
		containsBall = true;
		checkBall();
	}


	private void checkBall(){
		if(containsBall & ball != null){
			switch (id)
			{
				case 1:
					if(ball.getNumber() == 1 && ball.getColour() == 3){
						locked = true;
						StartCoroutine(lookUpAndFill(1));
					}
					break;

				case 2:
					if(ball.getNumber() == 2 && ball.getColour() == 1){
						locked = true;
						StartCoroutine(lookUpAndFill(2));
					}
					break;

				case 3:
					if(ball.getNumber() == 3 && ball.getColour() == 2){
						locked = true;
						StartCoroutine(lookUpAndFill(3));
					}
					break;

				case 4:
					if(ball.getNumber() == 4 && ball.getColour() == 4){
						locked = true;
						StartCoroutine(lookUpAndFill(4));
					}
					break;

				default:
					break;
			}
		}
	}

	IEnumerator lookUpAndFill(int n){
		navigation.moveCameraUpandLock();
		yield return new WaitForSeconds(0.5f);
		controller.activate(n);
		yield return null;
	}

}
