using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBounds : MonoBehaviour {

	private void OnTriggerExit(Collider collision) {
		GameObject go = collision.gameObject;
		if(go.tag.Equals("RuneBall")){
			RuneBall ball = go.GetComponent<RuneBall>();
			ball.respawn();
			Debug.Log("Respawning!");
		}
		if(go.tag.Equals("Object")){
			ObjectDescriptor o = go.GetComponent<ObjectDescriptor>();
			o.respawn();
			Debug.Log("Respawning!");
		}
		if(go.tag.Equals("MathBall")){
			MathBall o = go.GetComponent<MathBall>();
			o.respawn();
			Debug.Log("Respawning!");
		}
		if(go.tag.Equals("RedBall")){
			RomanBall o = go.GetComponent<RomanBall>();
			o.respawn();
			Debug.Log("Respawning!");
		}
		if(go.tag.Equals("BlueBall")){
			RomanBall o = go.GetComponent<RomanBall>();
			o.respawn();
			Debug.Log("Respawning!");
		}
	}
}
