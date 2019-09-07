using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour {

	void Start () {
		GetComponent<Text> ().enabled = false;
	}

	//enables the text for the game over screen buttons
	void Update () {
		if (Score.gameOver && (HazardScript.t > 1f || CarScript.t > 1f)) {
			GetComponent<Text> ().enabled = true;
		}
	}
}
