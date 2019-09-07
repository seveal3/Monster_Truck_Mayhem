using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	//enables final score text for the game over screen
	void Start () {
		GetComponent<Text> ().enabled = false;
	}
		
	void Update () {
		if (Score.gameOver && (HazardScript.t > 1f || CarScript.t > 1f)) {
			GetComponent<Text> ().enabled = true;
		}
	}
}
