using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//controls the left/right movement of the player

	private float turningRate = 100f;
	private Quaternion targetRotation = Quaternion.identity;

	private float timeTakenDuringLerp = 1.0f;
	private float distanceToMove = 15;

	private bool isLerping;
	private bool isLerpingLeft;
	private bool isLerpingRight;

	private Vector3 startPosition;
	private Vector3 endPosition;

	private float timeStartedLerping;

	public static bool particles = true;

	void Start(){
		tag = "Player";
		TutorialGameController.tutorialComplete = false;
	}

	//Lerps from left to right
	void StartLerpingRight()
	{
		if (!Score.gameOver && !TutorialGameController.tutorialComplete) {
			isLerping = true;
			isLerpingRight = true;
			timeStartedLerping = Time.time;

			SetEuler (new Vector3 (50, 120, 0));

			startPosition = transform.position;
			endPosition = transform.position + Vector3.right*distanceToMove;
		}
	}

	//Lerps from right to left
	void StartLerpingLeft()
	{
		if (!Score.gameOver && !TutorialGameController.tutorialComplete) {
			isLerping = true;
			isLerpingLeft = true;
			timeStartedLerping = Time.time;

			SetEuler (new Vector3 (-50, 60, 0));

			startPosition = transform.position;
			endPosition = transform.position + Vector3.left * distanceToMove;
		}
	}


	public void SetEuler(Vector3 angles){
		targetRotation = Quaternion.Euler (angles);
	}

	//sets the movement when an arrow key is pressed
	//sets max/min x values so that the player stays on the road
	void Update()
	{
		
		if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) == false && isLerping == false && (transform.position.x < 14))
		{
			StartLerpingRight();
		}

		if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) == false && isLerping == false && (transform.position.x > -14))
		{
			StartLerpingLeft();
		}

		if (!particles) {
			for (int i = 0; i < gameObject.transform.childCount; i++) {
				ParticleSystem p = gameObject.transform.GetChild (i).GetComponent<ParticleSystem> ();
				if (p != null) {
					p.Pause(true);
				}
			}
		}
	}
		
	//sets Lerping movement and rotation
	void FixedUpdate()
	{

		if (isLerping) {
			
			float timeSinceStarted = Time.time - timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, turningRate * Time.deltaTime);
			transform.position = Vector3.Lerp (startPosition, endPosition, 5 * percentageComplete);

			if (5 * percentageComplete >= 1.0f) {
				isLerping = false;
				isLerpingLeft = false;
				isLerpingRight = false;
			}
		}

		if (isLerping == false) {
		
			SetEuler (new Vector3 (0, 90, 0));
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, 200f * Time.deltaTime);
		}
	}
}
	
