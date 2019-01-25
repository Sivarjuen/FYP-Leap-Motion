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
					}
					break;

				case 2:
					if(ball.getNumber() == 2 && ball.getColour() == 1){
						locked = true;
					}
					break;

				case 3:
					if(ball.getNumber() == 3 && ball.getColour() == 2){
						locked = true;
					}
					break;

				case 4:
					if(ball.getNumber() == 4 && ball.getColour() == 4){
						locked = true;
					}
					break;

				default:
					break;
			}
		}
	}

}
