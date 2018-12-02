using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreSceneManager : MonoBehaviour {

	private Text text;
	public GameObject textObj, textPanel, handModels, secondaryHandModels, leapMotion, continueButton;

	private void Awake() {
		textObj = GameObject.Find("IntroText");
		textPanel = GameObject.Find("TextPanel");
        text = textObj.GetComponent<Text>();
		textObj.SetActive(false);
		textPanel.SetActive(false);
		continueButton.SetActive(false);
	}

	IEnumerator Start () {
        handModels.SetActive(false);
		secondaryHandModels.SetActive(false);
		leapMotion.SetActive(false);
        yield return StartCoroutine("TextUpdate");
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator TextUpdate() {
		// Time to start
		yield return new WaitForSeconds(3);
		textObj.SetActive(true);
		textPanel.SetActive(true);
		text.text = "Welcome";
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Hand tracking will be enabled shortly";
		yield return new WaitForSeconds(6);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Remember that the LEAP Motion Controller can only track what it sees";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "So make sure any actions you perform can be seen clearly by the device";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.color = Color.green;
		text.text = "Hand tracking is now enabled";
		leapMotion.SetActive(true);
		handModels.SetActive(true);
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.color = Color.white;
		text.text = "Feel free to move your hand around to get a feel for the Leap Motion's capabilities";
		yield return new WaitForSeconds(7);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "When you have finished point towards the 'Continue' button with one of your index fingers to move on to the next stage";
		continueButton.SetActive(true);
		yield return new WaitForSeconds(7);
		text.text = "";
		textObj.SetActive(false);
		textPanel.SetActive(false);
		yield return null;
	}

	IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        print("WaitAndPrint " + Time.time);
    }
}
