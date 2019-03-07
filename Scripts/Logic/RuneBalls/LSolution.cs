using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSolution : MonoBehaviour {

	public int level = 1;	// 1 - Level 1-1, 2 - Level 3-1

	public bool checkBall(RuneBall ball, int id){
		switch(level){
			case 1:
				switch(id){
					case 1:
						return(ball.getNumber() == 2 && ball.getColour() == 4);
					case 2:
						return(ball.getNumber() == 4 && ball.getColour() == 2);
					case 3:
						return(ball.getNumber() == 1 && ball.getColour() == 1);
					case 4:
						return(ball.getNumber() == 3 && ball.getColour() == 3);
					default:
						return false;
				}
			case 2:
				Debug.LogError("Level 3-1 not completed!");
				return false;
			default:
				Debug.LogError("Level not set: 1 - Level 1-1, 2 - Level 3-1");
				return false;
		}
	}
}
