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
	}
}
