using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreBackground : MonoBehaviour {

	//enables background for the game over screen
	void Start () {
		GetComponent<Image> ().enabled = false;
	}
		
	void Update () {
		if (Score.gameOver && (HazardScript.t > 1f || CarScript.t > 1f)) {
			GetComponent<Image> ().enabled = true;
		}
	}
}
