using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectorRoman : MonoBehaviour {

	private RomanMathHolder holder;
	
	void Start(){
		holder = transform.parent.GetComponent<RomanMathHolder>();
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
