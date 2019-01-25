using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

	private Holder holder;
	
	void Start(){
		holder = transform.parent.GetComponent<Holder>();
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
