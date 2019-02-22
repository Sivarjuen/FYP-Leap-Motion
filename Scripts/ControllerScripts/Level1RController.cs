using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1RController : MonoBehaviour {

	public ArmController arm;
	public CraneController crane;
	public PowerPuzzle puzzle;
	public PlatformController[] platforms;
	private bool activated = false;
	public GameObject block;
	private bool blocksSolved;

	// Use this for initialization
	void Start () {
		blocksSolved = false;
		initialiseBlocks();	
	}
	
	// Update is called once per frame
	void Update () {
		if(!activated){
			if(puzzle.isCompleted()){
				activate();
				activated = true;
			}
		} else if(!blocksSolved) {
			blocksSolved = checkSolution();
		}
		if(blocksSolved){
			Debug.Log("SOLVED!");
		}
	}

	private bool checkSolution(){
		if(platforms.Length == 9){
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

		} else if(platforms.Length == 16) {
			//MEDIUM SOLUTION:
			//	Platform:	0	1	2	3	4	5	6	7	8	9	10	11	12	13	14	15
			//	Type:		G	Y	Y	B	G	G	B	G	Y	B	R	R	B	-	R	R
			int correct = 0;
			for(int i = 0; i < platforms.Length; i++){
				if(i == 0 || i == 4 || i == 5 || i == 7){
					if(platforms[i].blockType() == 2) correct++;
				} else if(i == 1 || i == 2 || i == 8){
					if(platforms[i].blockType() == 3) correct++;
				} else if(i == 3 || i == 6 || i == 9 || i == 12){
					if(platforms[i].blockType() == 0) correct++;
				} else if(i == 10 || i == 11 || i == 14 || i == 15){
					if(platforms[i].blockType() == 1) correct++;
				}
			}
			return correct == 15;
			
		} else if(platforms.Length == 25) {
			//HARD SOLUTION:
			//	Platform:	0	1	2	3	4	5	6	7	8	9	10	11	12
			//	Type:		Y	-	G	G	Y	B	Y	R	P	B	G	R	P
			//	Platform:	13	14	15	16	17	18	19	20	21	22	23	24
			//	Type:		R	B	B	G	R	G	-	R	Y	B	Y	P
			int correct = 0;
			for(int i = 0; i < platforms.Length; i++){
				if(i == 0 || i == 4 || i == 6 || i == 21 || i == 23){
					if(platforms[i].blockType() == 3) correct++;
				} else if(i == 8 || i == 12 || i == 24){
					if(platforms[i].blockType() == 4) correct++;
				} else if(i == 2 || i == 3 || i == 10 || i == 16 || i == 18){
					if(platforms[i].blockType() == 2) correct++;
				} else if(i == 5 || i == 9 || i == 14 || i == 15 || i == 22){
					if(platforms[i].blockType() == 0) correct++;
				} else if(i == 7 || i == 11 || i == 13 || i == 17 || i == 20){
					if(platforms[i].blockType() == 1) correct++;
				}
			}
			return correct == 24;	
			
		} else {
			return false;
		}
	}

	private void initialiseBlocks(){
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
		} else if(platforms.Length == 16){ // 4 blue, 4 red, 4 green, 3 yellow
			List<int> platformIndices = new List<int>(new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15});
			for(int i = 0; i < 15; i++){
				int type = 0;
				if(i >= 4) type = 1; 
				if(i >= 8) type = 2;
				if(i >= 12) type = 3;
				int indexTemp = Random.Range(0, platformIndices.Count);
				int index = platformIndices[indexTemp];
				spawnBlock(index, type);
				platformIndices.RemoveAt(indexTemp);
			}
		} else if(platforms.Length == 25){	// 5 blue, 5 red, 5 green, 5 yellow, 3 purple
			List<int> platformIndices = new List<int>(new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24});
			for(int i = 0; i < 23; i++){
				int type = 0;
				if(i >= 5) type = 1; 
				if(i >= 10) type = 2;
				if(i >= 15) type = 3;
				if(i >= 20) type = 4;
				int indexTemp = Random.Range(0, platformIndices.Count);
				int index = platformIndices[indexTemp];
				spawnBlock(index, type);
				platformIndices.RemoveAt(indexTemp);
			}
		}
	}

	private void activate(){
		arm.activate();
		crane.activate();
	}

	private void spawnBlock(int index, int type){
		GameObject new_block = Instantiate(block, platforms[index].blockPosition.position, platforms[index].blockPosition.rotation);
		Block blockScript = new_block.GetComponent<Block>();
		blockScript.initialise(type);
		platforms[index].setBlock(blockScript);
	}
}
