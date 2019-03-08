using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour {

	public GameObject highlight, successHighlight;
	public Transform objectPosition;
	private bool containsObject = false;
	private ObjectDescriptor obj;
	private int colliding = 0;
	private bool locked = false;
	public int id = 0;
	public bool colourBased = true;
	

	void Awake () {
		highlight.SetActive(false);
		successHighlight.SetActive(false);
	}
	
	void Update () {
		if(locked && obj != null){
			obj.freeze();
			obj.transform.position = objectPosition.position;
		}
	}

	
	public void ChildTriggerEnter(Collider collision) {
		if(!containsObject){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("Object")){
				colliding++;
				highlight.SetActive(true);
			}
		}
	}

	public void ChildTriggerExit(Collider collision) {
		GameObject go = collision.gameObject;
		if(go.tag.Equals("Object")){
			colliding--;
			if(colliding == 0){
				highlight.SetActive(false);
				containsObject = false;
				obj = null;
			}
		}
	}

	public void ChildTriggerStay(Collider collision) {
		if(!containsObject){
			GameObject go = collision.gameObject;
			if(go.tag.Equals("Object")){
				ObjectDescriptor objDesc = go.GetComponent<ObjectDescriptor>();
				if(!objDesc.isGrasped()){
					highlight.SetActive(false);
					go.transform.position = objectPosition.position;
					go.transform.rotation = objectPosition.rotation;
					objDesc.stopContact();
					setObject(objDesc);
				} else {
					highlight.SetActive(true);
				}
			}
		}
	}

	private void setObject(ObjectDescriptor obj){
		this.obj = obj;
		containsObject = true;
		checkObject();
	}

	private void checkObject(){
		if(containsObject && obj != null){
			if(colourBased){
				if(obj.getColour() == id){
					locked = true;
					successHighlight.SetActive(true);
					obj.freeze();
				}
			}
		}
	}

	public bool isLocked(){
		return locked;
	}
}

