using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisMovement : MonoBehaviour {

	//controls the speed of the debris in a large explosion

	public float speed;

	void Start(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	void Update(){
		Vector3 startPosition = transform.position;
		transform.position = startPosition + Vector3.forward * speed;
	}
}
