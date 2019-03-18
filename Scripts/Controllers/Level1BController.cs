using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1BController : AbstractRController {

	public PowerSlider power;

	override protected bool checkSolution(){
		//EASY SOLUTION:
		//	Platform:	0	1	2	3	4	5	6	7	8
		//	Type:		B	R	B	R	-	R	B	R	B
		int correct = 0;
		for(int i = 0; i < platforms.Length; i++){
			if(i == 0 || i == 2 || i == 6 || i == 8){
				if(platforms[i].blockType() == 0) correct++;
			} else if(i == 1 || i == 3 || i == 5 || i == 7){
				if(platforms[i].blockType() == 1) correct++;
			}
		}
		return correct == 8;
	}

	override protected void initialiseBlocks(){
		if(platforms.Length == 9){ // 4 blue, 4 red
			List<int> platformIndices = new List<int>(new int[] {0,1,2,3,4,5,6,7,8});
			for(int i = 0; i < 8; i++){
				int type = 0;
				if(i >= 4) type = 1; 
				int indexTemp = Random.Range(0, platformIndices.Count);
				int index = platformIndices[indexTemp];
				spawnBlock(index, type);
				platformIndices.RemoveAt(indexTemp);
			}
		} 
	}

	override protected void checkLevelSpecificCriteria(){
		if(power.isCompleted()){
			activate();
		}
	}

	override protected void loadNextLevel(){
		if(GameController.State == GameController.RIGHT_FINISHED){
			GameController.State = GameController.LEFT_AND_RIGHT_FINISHED;
		} else {
			GameController.State = GameController.LEFT_FINISHED;
		}
		SceneManager.LoadScene(1);
	}
}
