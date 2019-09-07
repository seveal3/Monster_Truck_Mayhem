using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour {

	//controls collisions with hazards

	public GameObject hazardExplosion;
	public GameObject playerExplosion;
	public static float t;

	void OnCollisionEnter(Collision other){

		GameObject c = other.gameObject;

		//if it is a barrier, destroy the player and the hazard
		if (gameObject.name == "Barrier(Clone)" && c.name == "Player") {
			Instantiate (hazardExplosion, transform.position, transform.rotation);
			Destroy (gameObject);
			Instantiate (playerExplosion, other.collider.transform.position, other.collider.transform.rotation);
			Destroy (c);
			EndGame ();
		}

		//if it is a blockade, end the game but do not destroy hazard or player
		if (gameObject.name == "Blockade(Clone)" && c.name == "Player") {

			//makes the blockade child objects kinematic so that they disperse on collision
			for (int i = 0; i < gameObject.transform.childCount; i++) {
				gameObject.transform.GetChild (i).GetComponent<Rigidbody> ().isKinematic = false;
			}
			gameObject.transform.DetachChildren ();
			gameObject.GetComponent<Rigidbody>().isKinematic = false; 
			EndGame ();

		}
	}

	void EndGame(){
		t = Time.time;
		Score.gameOver = true;
		GameController.running = false;
	}


	void Start(){
		t = 0;	
	}

	void Update(){
		if (Score.gameOver == true) {
			PlayerController.particles = false;
		}
	}
}
