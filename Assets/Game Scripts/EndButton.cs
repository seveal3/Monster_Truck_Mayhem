using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour {
	
	void Start () {
		GetComponent<Button> ().enabled = false;
		GetComponent<Image> ().enabled = false;
	}

	//enables the buttons for the game over screen
	void Update () {
		if (Score.gameOver && (HazardScript.t > 1f || CarScript.t > 1f)) {
			GetComponent<Button> ().enabled = true;
			GetComponent<Image> ().enabled = true;
		}
	}

}
