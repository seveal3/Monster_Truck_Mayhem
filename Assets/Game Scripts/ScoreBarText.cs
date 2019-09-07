using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBarText : MonoBehaviour {

	//disables score bar text at game over
	void Start () {
		GetComponent<Text> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Score.gameOver && (HazardScript.t > 1f || CarScript.t > 1f)) {
			GetComponent<Text> ().enabled = false;
		}

		if (RunTutorial.runningTutorial && name == "Time") {
			GetComponent<Text> ().enabled = false;
		}
	}
}
