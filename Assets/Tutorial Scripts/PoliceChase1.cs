using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliceChase1 : MonoBehaviour {

	//tutorial text

	void Start () {
		GetComponent<Text> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (RunTutorial.runningTutorial && !Score.gameOver) {
			if (Time.time > RunTutorial.t + 37.0f && Time.time < RunTutorial.t + 40.0f) {
				GetComponent<Text> ().enabled = true;
			} 

			if (Time.time > RunTutorial.t + 40.0f) {
				GetComponent<Text> ().enabled = false;
			} 
		}
	}
}
