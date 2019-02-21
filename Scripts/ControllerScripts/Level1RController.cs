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
	//SOLUTION:
		//	Platform:	0	1	2	3	4	5	6	7	8
		//	Type:		B	R	B	R	-	R	B	R	B
		if(platforms.Length == 9){
			int correct = 0;
			for(int i = 0; i < platforms.Length; i++){
				if(i == 0 || i == 2 || i == 6 || i == 8){
					if(platforms[i].blockType() == 0) correct++;
				} else if(i == 1 || i == 3 || i == 5 || i == 7){
					if(platforms[i].blockType() == 1) correct++;
				}
			}
			return correct == 8;

		} else {
			Debug.LogError("Level1RController - checkSolution - platform length !-= 9");
			return false;
		}
	}

	private void initialiseBlocks(){
		if(platforms.Length == 9){ // 4 blue, 4 red
			List<int> platformIndices = new List<int>(new int[] {0,1,2,3,4,5,6,7,8});
			for(int i = 0; i <= 7; i++){
				int type = 0;
				if(i >= 4) type = 1; 
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
