using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class AbstractRController : MonoBehaviour {

	public ArmController arm;
	public CraneController crane;
	public PlatformController[] platforms;
	private bool activated = false;
	public GameObject block;
	private bool blocksSolved;
	public GameObject blockingDoorObject, doorFrame;
	public Image door;
	private static float doorFillDuration = 5.0f;
	private float timer = 0.0f;
	private bool fillingDoor = false;
	public LeftRightNavigation navigation;

	// Use this for initialization
	void Start () {
		blocksSolved = false;
		initialiseBlocks();	
		doorFrame.SetActive(false);
		door.fillAmount = 0.0f;
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
			blockingDoorObject.SetActive(false);
			doorFrame.SetActive(true);
			navigation.moveToState(1);
			if(!fillingDoor){
				timer = Time.time;
				fillingDoor = true;
			}
			processCompletion();
		}
		checkLevelSpecificCriteria();
	}

	private void processCompletion(){
		float elapsed = Time.time - timer;
		if(door.fillAmount < 1.0f){
			door.fillAmount = elapsed / doorFillDuration;
		}
		if(door.fillAmount >= 1.0f){
			loadNextLevel();
		}
	}

	protected abstract bool checkSolution();

	protected abstract void initialiseBlocks();

	protected abstract void checkLevelSpecificCriteria();

	protected abstract void loadNextLevel();

	protected void activate(){
		arm.activate();
		crane.activate();
		activated = true;
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
