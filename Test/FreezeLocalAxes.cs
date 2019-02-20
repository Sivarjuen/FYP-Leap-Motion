using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeLocalAxes : MonoBehaviour {

	private Rigidbody rigidbody;
	public bool freezeAlongX = false;
    public bool freezeAlongY = false;
    public bool freezeAlongZ = false;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);

		if(freezeAlongX) localVelocity.x = 0;
		if(freezeAlongY) localVelocity.y = 0;
		if(freezeAlongZ) localVelocity.z = 0;
					
		rigidbody.velocity = transform.TransformDirection(localVelocity);
	}
}
