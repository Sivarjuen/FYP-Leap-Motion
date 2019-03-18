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
	public GameObject upIndicator, downIndicator;
	private bool facingUp;
	private int state;	// 0 - start (up), 1 - down first time, 2 - up first time, 3 - down second time, 4 - up second time, 5 - finished
	private UpDownNavigation navigation;
	public Material[] materials;
	private Renderer rendererUp, rendererDown;
	
	void Awake() {
		handModels.SetActive(false);
		leapMotion.SetActive(false);
		videoPlane.SetActive(false);
		downIndicator.SetActive(false);
		upIndicator.SetActive(false);
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
		topText.text = "This is the vertical navigation tutorial";
		yield return new WaitForSeconds(6);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "Here you will learn how to look up and down using your hands";
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
		topText.text = "You will see directional indicators on the edges of your screen to indicate which directions you can look in";
		yield return new WaitForSeconds(5);
		upIndicator.SetActive(true);
		downIndicator.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		upIndicator.SetActive(false);
		downIndicator.SetActive(false);
		yield return new WaitForSeconds(0.4f);
		upIndicator.SetActive(true);
		downIndicator.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		upIndicator.SetActive(false);
		downIndicator.SetActive(false);
		yield return new WaitForSeconds(0.4f);
		upIndicator.SetActive(true);
		downIndicator.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		upIndicator.SetActive(false);
		downIndicator.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "It's now your turn";
		yield return new WaitForSeconds(3);
		topText.text = "";
		yield return new WaitForSeconds(0.2f);
		topText.text = "Start by looking down";
		downIndicator.SetActive(true);
		leapMotion.SetActive(true);
		handModels.SetActive(true);
		navigation.activate();
		yield return null;
	}
	
	void Update () {
		if(navigation.active){
			if(navigation.isFacingUp()){
				downIndicator.SetActive(true);
				upIndicator.SetActive(false);
			} else {
				downIndicator.SetActive(false);
				upIndicator.SetActive(true);
			}
			
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
	}

	IEnumerator triggerProgress(){
		yield return new WaitForSeconds(.4f);
		switch(state){
					case 0:
						//Do nothing
						break;
					case 1:
						//downIndicator.SetActive(false);
						toggleLight(1, 1);
						topText.text = "";
						bottomText.text = "Now look up";
						//upIndicator.SetActive(true);
						break;
					case 2:
						//upIndicator.SetActive(false);
						toggleLight(0, 1);
						topText.text = "Great! Now look down again...";
						//downIndicator.SetActive(true);
						break;
					case 3:
						//downIndicator.SetActive(false);
						toggleLight(1, 2);
						bottomText.text = "... and look up";
						//upIndicator.SetActive(true);
						break;
					case 4:
						//downIndicator.SetActive(true);
						//upIndicator.SetActive(false);
						toggleLight(0, 2);
						topText.text = "Remember the LEAP Motion is not perfect, so it might take multiple tries to look in a different direction";
						bottomText.text = "Remember the LEAP Motion is not perfect, so it might take multiple tries to look in a different direction";
						yield return new WaitForSeconds(8f);
						topText.text = "";
						bottomText.text = "";
						yield return new WaitForSeconds(.2f);
						topText.text = "While the next tutorial room is being prepared, feel free to practice looking up and down a few more times";
						bottomText.text = "While the next tutorial room is being prepared, feel free to practice looking up and down a few more times";
						yield return new WaitForSeconds(12f);
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
		SceneManager.LoadScene(3);
	}
}
