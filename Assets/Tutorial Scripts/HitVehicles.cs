using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitVehicles : MonoBehaviour {

	//tutorial text

	void Start () {
		GetComponent<Text> ().enabled = false;
	}


	void Update () {
		if (RunTutorial.runningTutorial && !Score.gameOver) {
			if (Time.time > RunTutorial.t + 8.0f && Time.time < RunTutorial.t + 15.0f) {
				GetComponent<Text> ().enabled = true;
			} 

			if (Time.time > RunTutorial.t + 15.0f) {
				GetComponent<Text> ().enabled = false;
			} 
		}
	}
}
