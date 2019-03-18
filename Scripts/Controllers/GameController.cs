using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController {

	private static int state = 0;
	public static int START = 0;
	public static int AFTER_TUTORIAL = 1;
	public static int LEFT_FINISHED = 2;
	public static int RIGHT_FINISHED = 3;
	public static int LEFT_AND_RIGHT_FINISHED = 4;
	public static int END = 5;

	public static int State{
		get {
			return state;
		}
		set {
			state = value;
		}
	}
}
