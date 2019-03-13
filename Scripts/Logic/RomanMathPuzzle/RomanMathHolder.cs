using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanMathHolder : MonoBehaviour {

	public GameObject highlight;
	public Transform ballPosition;
	public RomanMathPuzzle puzzle;
	private int colliding = 0;
	private bool containsBall = false;
	public int value;
	public bool left = true;
	private string ballTag = "";

	void Awake () {
		highlight.SetActive(false);
	}

	void Start(){
		if(left){
			ballTag = "RedBall";
		} else {
			ballTag = "BlueBall";
		}
	}
	

	public void ChildTriggerEnter(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals(ballTag)){
				colliding++;
				highlight.SetActive(true);
			}
		}
	}

	public void ChildTriggerExit(Collider collision) {
		GameObject go = collision.gameObject;
		if(go.tag.Equals(ballTag)){
			colliding--;
			if(colliding == 0){
				highlight.SetActive(false);
				containsBall = false;
				updatePuzzle(-1);
			}
		}
	}

	public void ChildTriggerStay(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals(ballTag)){
				RomanBall ball = go.GetComponent<RomanBall>();
				if(!ball.isGrasped()){
					highlight.SetActive(false);
					go.transform.position = ballPosition.position; //TWEAK THIS
					go.transform.rotation = ballPosition.rotation;
					ball.stopContact();
					containsBall = true;
					updatePuzzle(value);
				} else {
					highlight.SetActive(true);
				}
			}
		}
	}

	private void updatePuzzle(int i){
		if(left){
			puzzle.updateLeft(i);
		} else {
			puzzle.updateRight(i);
		}
	}
}
