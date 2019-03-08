using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionDetector : MonoBehaviour {

	private ObjectHolder holder;

	void Start(){
		holder = transform.parent.GetComponent<ObjectHolder>();
	}
	
	
	private void OnTriggerEnter(Collider other) {
		holder.ChildTriggerEnter(other);
	}

	private void OnTriggerStay(Collider other) {
		holder.ChildTriggerStay(other);
	}

	private void OnTriggerExit(Collider other) {
		holder.ChildTriggerExit(other);
	}
}
