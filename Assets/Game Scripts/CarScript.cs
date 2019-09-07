using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour {

	//controls all collisions with enemy vehicles

	public GameObject explosion;
	public GameObject collider;
	public Text pointsText;
	public float fadeSpeed;

	private float timeStartedLerping;
	private float timeTakenDuringLerp;
	private bool move;
	private Text obj;
	private int points;
	public static float t;
	private string ogTag;

	void Start(){
		points = 50;
		ogTag = tag;
	}

	//checks the collision has occurred with either a player object, or an object that has already been hit
	void Update(){

		if (collider != null && (collider.gameObject.name == "Player" || collider.gameObject.tag == "Touched")) {
			StartCoroutine(wait());
		}
	}

	//sets points for the collision and stops the game if a collision occurs during the 'police' period
	void OnCollisionEnter(Collision other){
		t = Time.time;
		collider = other.gameObject;

		//tutorial gameplay
		if (RunTutorial.runningTutorial) {
			if (!TutorialTextFade.police && (collider.name == "Player" || collider.tag == "Touched")) {
				Score.score = Score.score + points;
				setPoints (other);
				gameObject.tag = "Touched";
			}

			if (TutorialTextFade.police && collider.name == "Player") {
				Score.gameOver = true;
				PlayerController.particles = false;
			}
		}

		//normal gameplay
		if (!RunTutorial.runningTutorial) {
			if (!TextureFade.police && (collider.name == "Player" || collider.tag == "Touched")) {
				Score.score = Score.score + points;
				setPoints (other);
				gameObject.tag = "Touched";
			}

			if (TextureFade.police && collider.name == "Player") {
				Score.gameOver = true;
				PlayerController.particles = false;
			}
		}
	}

	//sets the wait time before the explosions in collisions
	IEnumerator wait(){
		if (ogTag == "Bus") {

			if (!Score.gameOver) {
				yield return new WaitForSeconds (0.2f);
			}
			Collide ();
		}

		if (ogTag == "Car") {
			if (!Score.gameOver) {
				yield return new WaitForSeconds (0.1f);
			}
			Collide ();
		}
	}

	//creates explosion and destroys game object in a collision
	//stops the game if the collision causes the game to end
	void Collide(){
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);

		if (Score.gameOver) {
			GameController.running = false;
		}
	}

	//creates points text at point of collision 
	void setPoints(Collision other){
		pointsText.text = points.ToString ();

		obj = Instantiate (pointsText, other.gameObject.transform.position, Quaternion.identity) as Text;
		obj.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);


		obj.rectTransform.position = new Vector3 (390 + other.transform.position.x*15, 340 + other.transform.position.y*15);
		StartCoroutine( fade ());
		Destroy (obj.gameObject, 0.6f);

	}

	//fades the points text at the point of collision
	IEnumerator fade(){
		yield return new WaitForSeconds (0.1f);
		obj.CrossFadeAlpha(0.0f, 0.4f, false);
	}
}
