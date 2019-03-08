using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : Holder {

	public int id = 0;
	public LSolution solution;
	public GameObject successHighlight;

	override protected void setRuneBall(RuneBall ball){
		this.ball = ball;
		containsBall = true;
		checkBall();
	}


	private void checkBall(){
		if(containsBall & ball != null){
			if(solution.checkBall(ball, id)){
				locked = true;
				successHighlight.SetActive(true);
				StartCoroutine(lookUpAndFill(id));
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
