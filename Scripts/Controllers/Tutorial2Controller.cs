using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial2Controller : MonoBehaviour {

	public VideoPlayer player;
	public GameObject videoPlane;
	public TextMeshProUGUI text;
	public GameObject frontArrowRight, rightArrowRight, backArrowRight, leftArrowRight;
	public GameObject frontArrowLeft, rightArrowLeft, backArrowLeft, leftArrowLeft;
	public GameObject frontLight, rightLight, backLight, leftLight;
	public GameObject handModels, leapMotion;
	public GameObject rightIndicator, leftIndicator;
	private int state;	// 0 - front, 1 - right, 2 - back, 3 - left, 4 - front, 5 - left, 6 - back, 7 - right, 8 - front, 9 - free
	public LeftRightNavigation navigation;
	public Material[] materials;
	private Renderer rendererFront, rendererRight, rendererBack, rendererLeft;
	private int facing = 0; // 0 - front, 1 - right, 2 - back, 3 - left
	
	void Awake() {
		handModels.SetActive(false);
		leapMotion.SetActive(false);
		videoPlane.SetActive(false);
		frontArrowRight.SetActive(false);
		frontArrowLeft.SetActive(false);
		rightArrowLeft.SetActive(false);
		backArrowLeft.SetActive(false);
		leftArrowLeft.SetActive(false);
		rightIndicator.SetActive(false);
		leftIndicator.SetActive(false);
		player.playOnAwake = false;
		player.isLooping = true;
		text.text = "";
		state = 0;
	}

	void Start() {
		rendererFront = frontLight.GetComponent<Renderer>();
		rendererRight = rightLight.GetComponent<Renderer>();
		rendererBack = backLight.GetComponent<Renderer>();
		rendererLeft = leftLight.GetComponent<Renderer>();
		toggleLight(0, 0);
		toggleLight(1, 0);
		toggleLight(2, 0);
		toggleLight(3, 0);
		navigation.lockLeftMovement(true);
		navigation.lockRightMovement(true);
		StartCoroutine("DelayedStart");
	}

	IEnumerator DelayedStart() { //TODO
		player.Prepare();
		yield return new WaitForSeconds(1);
		text.text = "This is the horizontal navigation tutorial";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Here you will learn how to look left and right using your hands";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Examine the demonstration below to see how this is done";
		yield return new WaitForSeconds(2);
		videoPlane.SetActive(true);
		player.Play();
		yield return new WaitForSeconds(8);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "To look right, rotate both of your hands clockwise so that your palms are facing left";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "And to look left, rotate your hands anticlockwise so that your palms are facing right";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Like before, you will have directional indicators on the edge of your screen to show which directions you can look";
		yield return new WaitForSeconds(6);
		leftIndicator.SetActive(true);
		rightIndicator.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		leftIndicator.SetActive(false);
		rightIndicator.SetActive(false);
		yield return new WaitForSeconds(0.4f);
		leftIndicator.SetActive(true);
		rightIndicator.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		leftIndicator.SetActive(false);
		rightIndicator.SetActive(false);
		yield return new WaitForSeconds(0.4f);
		leftIndicator.SetActive(true);
		rightIndicator.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		leftIndicator.SetActive(false);
		rightIndicator.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "It's now your turn";
		yield return new WaitForSeconds(3);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Start by looking right";
		leapMotion.SetActive(true);
		handModels.SetActive(true);
		yield return new WaitForSeconds(2);
		text.text = "";
		frontArrowRight.SetActive(true);
		rightIndicator.SetActive(true);
		navigation.activate();
		navigation.lockRightMovement(false);
		yield return null;
	}
	
	void Update () {
		if(facing != navigation.facing){ // If change in looking direction
			state++;
			facing = navigation.facing;
			StartCoroutine(triggerProgress());
		}
	}

	IEnumerator triggerProgress(){
		yield return new WaitForSeconds(.4f);
		switch(state){
					case 0:
						// Should never reach this
						break;
					case 1:
						toggleLight(1, 1);
						frontArrowRight.SetActive(false);
						break;
					case 2:
						rightArrowRight.SetActive(false);
						rightArrowLeft.SetActive(true);
						toggleLight(2, 1);
						break;
					case 3:
						backArrowRight.SetActive(false);
						backArrowLeft.SetActive(true);
						toggleLight(3, 1);
						break;
					case 4:
						leftArrowRight.SetActive(false);
						leftArrowLeft.SetActive(true);
						rightIndicator.SetActive(false);
						toggleLight(0, 1);
						navigation.lockRightMovement(true);
						navigation.lockLeftMovement(false);
						yield return new WaitForSeconds(0.2f);
						text.text = "Now look left";
						yield return new WaitForSeconds(3);
						text.text = "";
						frontArrowLeft.SetActive(true);
						leftIndicator.SetActive(true);
						break;
					case 5:
						frontArrowLeft.SetActive(false);
						toggleLight(3, 2);
						break;
					case 6:
						leftArrowLeft.SetActive(false);
						toggleLight(2, 2);
						break;
					case 7:
						backArrowLeft.SetActive(false);
						toggleLight(1, 2);
						break;
					case 8:
						frontArrowRight.SetActive(false);
						frontArrowLeft.SetActive(false);
						rightArrowRight.SetActive(false);
						rightArrowLeft.SetActive(false);
						backArrowRight.SetActive(false);
						backArrowLeft.SetActive(false);
						leftArrowRight.SetActive(false);
						leftArrowLeft.SetActive(false);
						toggleLight(0, 2);
						navigation.lockRightMovement(true);
						navigation.lockLeftMovement(true);
						leftIndicator.SetActive(false);
						rightIndicator.SetActive(false);
						text.text = "You're ready to tackle THE COMPLEX!";
						yield return new WaitForSeconds(4f);
						text.text = "3";
						yield return new WaitForSeconds(1f);
						text.text = "";
						yield return new WaitForSeconds(.1f);
						text.text = "2";
						yield return new WaitForSeconds(1f);
						text.text = "";
						yield return new WaitForSeconds(.1f);
						text.text = "1";
						yield return new WaitForSeconds(1f);
						text.text = "";
						yield return new WaitForSeconds(.1f);
						text.text = "Loading...";
						loadLevel();
						break;
					case 9:
						//Do nothing
						break;
				}
		yield return null;
	}

	private void toggleLight(int index, int stage){
		switch(index){
			case 0:
				rendererFront.material = materials[stage];
				break;
			case 1:
				rendererRight.material = materials[stage];
				break;
			case 2:
				rendererBack.material = materials[stage];
				break;
			case 3:
				rendererLeft.material = materials[stage];
				break;
		}
	}

	private void loadLevel(){
		GameController.State = GameController.AFTER_TUTORIAL;
		SceneManager.LoadScene(1);
	}
}
