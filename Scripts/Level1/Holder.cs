using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Holder : MonoBehaviour {

	public CapsuleCollider collider;
	public GameObject highlight;
	protected bool containsBall = false;
	protected RuneBall ball;
	protected int colliding = 0;

	void Awake () {
		highlight.SetActive(false);
	}

	void Start() {
	}
	
	void Update () {
		
	}

	
	public void ChildTriggerEnter(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("RuneBall")){
				colliding++;
				highlight.SetActive(true);
			}
		}
	}

	public void ChildTriggerExit(Collider collision) {
		if(!containsBall){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("RuneBall")){
				colliding--;
				if(colliding == 0){
					highlight.SetActive(false);
				}
			}
		}
	}

	public void ChildTriggerStay(Collider collision) {
		//TODO - see if ball is dropped or not
	}

	public void setRuneBall(RuneBall ball){
		this.ball = ball;
	}

	//TODO When ball is in collider -> turn on highlighter while ball still grabbed. When let go release into defined spot.
}
