using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3BController : AbstractRController {

	public PowerPuzzle puzzle;
	public PuzzleController puzzleController;
	
	override protected bool checkSolution(){
			//HARD SOLUTION:
			//	Platform:	0	1	2	3	4	5	6	7	8	9	10	11	12
			//	Type:		P	P	B	-	R	B	G	Y	R	B	Y	R	P
			//	Platform:	13	14	15	16	17	18	19	20	21	22	23	24
			//	Type:		Y	Y	G	W	-	B	P	R	B	G	G	R
			int correct = 0;
			for(int i = 0; i < platforms.Length; i++){

				if(i == 2 || i == 5 || i == 9 || i == 18 || i == 21){
					if(platforms[i].blockType() == 0) correct++;
				} else if(i == 4 || i == 8 || i == 11 || i == 20 || i == 24){
					if(platforms[i].blockType() == 1) correct++;
				} else if(i == 6 || i == 15 || i == 22 || i == 23){
					if(platforms[i].blockType() == 2) correct++;
				} else if(i == 7 || i == 10 || i == 13 || i == 14){
					if(platforms[i].blockType() == 3) correct++;
				} else if(i == 0 || i == 1 || i == 12 || i == 19){
					if(platforms[i].blockType() == 4) correct++;
				} else if(i == 16){
					if(platforms[i].blockType() == 5) correct++;
				}
			}
			return correct == 23;	// 25 platforms - 2 empty platforms
	}

	override protected void initialiseBlocks(){
		if(platforms.Length == 25){	// 5 blue, 5 red, 4 green, 4 yellow, 4 purple, 1 white
			List<int> platformIndices = new List<int>(new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24});
			for(int i = 0; i < 23; i++){
				int type = 0;
				if(i >= 5) type = 1; 
				if(i >= 10) type = 2;
				if(i >= 14) type = 3;
				if(i >= 18) type = 4;
				if(i >= 22) type = 5;
				int indexTemp = Random.Range(0, platformIndices.Count);
				int index = platformIndices[indexTemp];
				spawnBlock(index, type);
				platformIndices.RemoveAt(indexTemp);
			}
		}
	}

	override protected void checkLevelSpecificCriteria(){
		if(puzzle.isCompleted()){
			activate();
			puzzleController.activate();
		}
	}

	override protected void loadNextLevel(){
		GameController.State = GameController.END;
		SceneManager.LoadScene(1);
	}
}
