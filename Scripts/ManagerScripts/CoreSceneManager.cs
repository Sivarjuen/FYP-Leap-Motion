using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreSceneManager : MonoBehaviour {

	private Text text;
	public GameObject handModels;
	private float timeLeft = 3.0f;

	private void Awake() {
        text = GameObject.Find("IntroText").GetComponent<Text>();
		//handModels = GameObject.Find("Rigged Hand Models");
	}

	IEnumerator Start () {
        // Start function WaitAndPrint as a coroutine
        yield return StartCoroutine("TextUpdate");
        print("Done " + Time.time);
	}
	
	// Update is called once per frame
	void Update () {


	}

	IEnumerator TextUpdate() {
		// Time to start
		//timeLeft -= Time.deltaTime;
		yield return new WaitForSeconds(5);
		text.text = "Welcome";
		yield return new WaitForSeconds(4);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Hand tracking will be enabled shortly";
		yield return new WaitForSeconds(8);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Remember that the LEAP Motion Controller can only track what it sees";
		yield return new WaitForSeconds(8);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "So make sure any actions you perform can be seen clearly by the device";
		yield return new WaitForSeconds(8);
		text.text = "";
		yield return new WaitForSeconds(0.2f);
		text.text = "Hand tracking is now enabled";
		handModels.SetActive(true);

		yield return null;
	}

	IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        print("WaitAndPrint " + Time.time);
    }
}
