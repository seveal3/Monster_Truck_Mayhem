using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour {

	//controls movement of fire in an explosion after a collision
	public float speed;

	void Start(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	void Update(){
		Vector3 startPosition = transform.position;
		transform.position = startPosition + Vector3.back * speed;
	}

}
