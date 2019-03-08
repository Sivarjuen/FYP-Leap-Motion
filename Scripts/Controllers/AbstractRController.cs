using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRController : MonoBehaviour {

	public ArmController arm;
	public CraneController crane;
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
			if(Input.GetKeyDown(KeyCode.M)){
				activate();
				activated = true;
		}
		} else if(!blocksSolved) {
			blocksSolved = checkSolution();
		}
		if(blocksSolved){
			Debug.Log("SOLVED!");
		}
		checkLevelSpecificCriteria();
	}

	protected abstract bool checkSolution();

	protected abstract void initialiseBlocks();

	protected abstract void checkLevelSpecificCriteria();

	protected void activate(){
		arm.activate();
		crane.activate();
	}

	protected void spawnBlock(int index, int type){
		GameObject new_block = Instantiate(block, platforms[index].blockPosition.position, platforms[index].blockPosition.rotation);
		Block blockScript = new_block.GetComponent<Block>();
		blockScript.initialise(type);
		platforms[index].setBlock(blockScript);
	}

	public bool isActivated(){
		return activated;
	}
}
