using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial1Controller : MonoBehaviour {

	public VideoPlayer player;
	public GameObject videoPlane;
	public TextMeshProUGUI topText, bottomText;
	public GameObject topLight, bottomLight;
	public GameObject handModels, leapMotion;
	private bool facingUp;
	private int state;	// 0 - start (up), 1 - down first time, 2 - up first time, 3 - down second time, 4 - up second time, 5 - finished
	private UpDownNavigation navigation;
	public Material[] materials;
	private Renderer rendererUp, rendererDown;
	
	void Awake() {
		handModels.SetActive(false);
		leapMotion.SetActive(false);
		videoPlane.SetActive(false);
		player.playOnAwake = false;
		player.isLooping = true;
		topText.text = "";
		bottomText.text = "";
		facingUp = true;
		state = 0;
	}

	void Start() {
		navigation = GetComponent<UpDownNavigation>();
		rendererUp = topLight.GetComponent<Renderer>();
		rendererDown = bottomLight.GetComponent<Renderer>();
		toggleLight(0, 0);
		toggleLight(1, 0);
		StartCoroutine("DelayedStart");
	}

	IEnumerator DelayedStart() {
		player.Prepare();
		yield return new WaitForSeconds(1);
		topText.text = "Wait!";
		yield return new WaitForSeconds(3);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "The room you're about to enter will require you to look up and down";
		yield return new WaitForSeconds(6);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "Examine the demonstration below to see how this is done";
		yield return new WaitForSeconds(2);
		videoPlane.SetActive(true);
		player.Play();
		yield return new WaitForSeconds(6);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "To look down you point both of your hands down so that your palms are facing you";
		yield return new WaitForSeconds(6);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "And to look up you hold your hands up so that your palms are facing away from you";
		yield return new WaitForSeconds(6);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "It's now your turn";
		yield return new WaitForSeconds(3);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "Start by looking down";
		leapMotion.SetActive(true);
		handModels.SetActive(true);
		yield return null;
	}
	
	void Update () {
		if(facingUp != navigation.isFacingUp()){ // If change in looking direction
			if(navigation.isFacingUp()){ //Looking up
				facingUp = true;
				switch(state){
					case 1:
						state = 2;
						break;
					case 3:
						state = 4;
						break;
					case 5:
						break;
				}
			} else { // Looking down
				facingUp = false;
				switch(state){
					case 0:
						state = 1;
						break;
					case 2:
						state = 3;
						break;
					case 4:
						state = 5;
						break;
					case 5:
						break;
				}
			}
			StartCoroutine(triggerProgress());
		}
	}

	IEnumerator triggerProgress(){
		yield return new WaitForSeconds(.4f);
		switch(state){
					case 0:
						//Do nothing
						break;
					case 1:
						toggleLight(1, 1);
						topText.text = "";
						bottomText.text = "Great job! Now look up!";
						break;
					case 2:
						toggleLight(0, 1);
						topText.text = "You're getting the hang of this. Look down again!";
						break;
					case 3:
						toggleLight(1, 2);
						bottomText.text = "This is the last one I promise. Look up!";
						break;
					case 4:
						toggleLight(0, 2);
						topText.text = "You're ready to tackle the first level";
						bottomText.text = "";
						yield return new WaitForSeconds(4f);
						topText.text = "";
						yield return new WaitForSeconds(.2f);
						topText.text = "While we are preparing the room, feel free to practice looking up and down a few more times";
						yield return new WaitForSeconds(17f);
						topText.text = "3";
						bottomText.text = "3";
						yield return new WaitForSeconds(1f);
						topText.text = "";
						bottomText.text = "";
						yield return new WaitForSeconds(.1f);
						topText.text = "2";
						bottomText.text = "2";
						yield return new WaitForSeconds(1f);
						topText.text = "";
						bottomText.text = "";
						yield return new WaitForSeconds(.1f);
						topText.text = "1";
						bottomText.text = "1";
						yield return new WaitForSeconds(1f);
						topText.text = "";
						bottomText.text = "";
						yield return new WaitForSeconds(.1f);
						topText.text = "Loading...";
						bottomText.text = "Loading...";
						loadLevel();
						break;
					case 5:
						//Do nothing
						break;

				}
		yield return null;
	}

	private void toggleLight(int index, int stage){
		if(index == 0){
			rendererUp.material = materials[stage];
		} else {
			rendererDown.material = materials[stage];
		}
	}

	private void loadLevel(){
		// Load level 1 here
		// TODO
	}
}
