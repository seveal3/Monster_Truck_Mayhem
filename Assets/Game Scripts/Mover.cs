using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	//controls the speed of the enemy vehicles and hazards

	public float speed;

	void Start(){

		speed = 0.55f;

		if (tag == "Hazard") {
			speed = 0.90f;	
		}

		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;

	}

	void Update(){
		Vector3 startPosition = transform.position;
		transform.position = startPosition + Vector3.back * speed;
	}
}
