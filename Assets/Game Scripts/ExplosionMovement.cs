using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMovement : MonoBehaviour {

	//controls the speed of the explosion after a collision

	public float speed;

	void Start(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;

	}
		
	void Update(){
		Destroy (gameObject, 3);
		Vector3 startPosition = transform.position;
		transform.position = startPosition + Vector3.back * speed;
	}
}
