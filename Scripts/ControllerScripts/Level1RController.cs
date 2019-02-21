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

	//SOLUTION:
		//		Platform:	0	1	2	3	4	5	6	7	8
		//		Type:		B	R	B	R	-	R	B	R	B


	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
		if(!activated){
			if(puzzle.isCompleted()){
				activate();
				activated = true;
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
