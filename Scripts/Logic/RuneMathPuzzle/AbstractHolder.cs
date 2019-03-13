using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHolder : MonoBehaviour {

	public GameObject highlight;
	public Transform ballPosition;
	protected int colliding = 0;
	protected bool containsBall = false;
	protected MathBall ball;
	protected bool locked = false;

	void Awake () {
		highlight.SetActive(false);
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(locked && ball != null){
			ball.freeze();
		}

		if(containsBall){
			updateValue();
		}
	}

	public void ChildTriggerEnter(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("MathBall")){
				colliding++;
				highlight.SetActive(true);
			}
		}
	}

	public void ChildTriggerExit(Collider collision) {
		GameObject go = collision.gameObject;
		if(go.tag.Equals("MathBall")){
			colliding--;
			if(colliding == 0){
				highlight.SetActive(false);
				containsBall = false;
				ball = null;
			}
		}
	}

	public void ChildTriggerStay(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("MathBall")){
				MathBall mathBall = go.GetComponent<MathBall>();
				if(!mathBall.isGrasped()){
					highlight.SetActive(false);
					go.transform.position = ballPosition.position; //TWEAK THIS
					go.transform.rotation = ballPosition.rotation;
					mathBall.stopContact();
					setBall(mathBall);
				} else {
					highlight.SetActive(true);
				}
			}
		}
	}


	private void setBall(MathBall ball){
		this.ball = ball;
		containsBall = true;
	}

	protected abstract void updateValue();
}
