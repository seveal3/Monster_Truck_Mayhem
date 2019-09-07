using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialComplete : MonoBehaviour {
	//enables tutorial complete text

	void Start () {
		GetComponent<Text> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (TutorialGameController.tutorialComplete && !Score.gameOver) {
			GetComponent<Text> ().enabled = true;
		}
	}
}
