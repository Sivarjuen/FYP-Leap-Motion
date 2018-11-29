using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class BasicMovement : MonoBehaviour {

	Controller controller;
	//float HandPalmPitch;
	float HandPalmYaw;
	//float HandPalmRoll;
	//float HandWristRot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		controller = new Controller();
		Frame frame = controller.Frame();
		List<Hand> hands = frame.Hands;
		if(frame.Hands.Count > 0){
			Hand firstHand = hands[0];
			//HandPalmPitch = firstHand.PalmNormal.Pitch;
			HandPalmYaw = firstHand.PalmNormal.Yaw;
			//HandPalmRoll = firstHand.PalmNormal.Roll;
			//HandWristRot = hands[0].WristPosition.Pitch;

			//Debug.Log("Pitch :" + HandPalmPitch);
			//Debug.Log("Roll :" + HandPalmRoll);
			//Debug.Log("Yaw :" + HandPalmYaw);

			//Move Object
			if(HandPalmYaw > -2f && HandPalmYaw < 3.5f){
				transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime)); 
			} else if (HandPalmYaw < -2.2f){
				transform.Translate(new Vector3(0,0, -1 * Time.deltaTime));
			}
		}
	}
}