using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public static float scrollSpeed;
	public float tileLength;
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
		scrollSpeed = -70;
	}
	
	////Sets the speed of the road background
	void Update () {
		float y = Mathf.Repeat (Time.time * scrollSpeed, tileLength);
		transform.position = startPosition + Vector3.forward * y;

		//stops the road if neither the game or the tutorial are running
		if (!GameController.running && !RunTutorial.runningTutorial) {
			scrollSpeed = 0;
		}

		//sets the road speed for the tutorial
		if (RunTutorial.runningTutorial && !Score.gameOver && !TutorialGameController.tutorialComplete) {
			scrollSpeed = -55;
		}

		//stops the road during the tutorial if the game is over or the tutorial is complete
		if (RunTutorial.runningTutorial && (Score.gameOver || TutorialGameController.tutorialComplete)) {
			scrollSpeed = 0;
		}
	}
}
