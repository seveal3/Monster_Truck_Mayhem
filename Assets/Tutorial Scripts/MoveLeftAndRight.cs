using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLeftAndRight : MonoBehaviour {

	//tutorial text

	void Start () {
		GetComponent<Text> ().enabled = true;
	}

	// Update is called once per frame
	void Update () {
		if (RunTutorial.runningTutorial && !Score.gameOver) {
			if (Time.time > RunTutorial.t + 7.0f) {
				GetComponent<Text> ().enabled = false;
			} 
		}
	}
}
