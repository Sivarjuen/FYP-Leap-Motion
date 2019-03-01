using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSolution : MonoBehaviour {

	public int difficulty = 0;

	public bool checkBall(RuneBall ball, int id){
		switch(difficulty){
			case 1:
				switch(id){
					case 1:
						return(ball.getNumber() == 1 && ball.getColour() == 3);
					case 2:
						return(ball.getNumber() == 2 && ball.getColour() == 1);
					case 3:
						return(ball.getNumber() == 3 && ball.getColour() == 2);
					case 4:
						return(ball.getNumber() == 4 && ball.getColour() == 4);
					default:
						return false;
				}
			case 2:
				//todo
				Debug.LogError("Not implemented");
				return false;
			case 3:
				//todo
				Debug.LogError("Not implemented");
				return false;
			default:
				Debug.LogError("Difficulty not set: 1 - Easy, 2 - Medium, 3 - Hard");
				return false;
		}
	}
}
