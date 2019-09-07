using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCompleteButton : MonoBehaviour {
	
	void Start () {
		GetComponent<Button> ().enabled = false;
		GetComponent<Image> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (TutorialGameController.tutorialComplete && !Score.gameOver) {
			GetComponent<Button> ().enabled = true;
			GetComponent<Image> ().enabled = true;
		}
	}
}
