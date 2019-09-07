using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	//enables game over text
	void Start () {
		GetComponent<Text> ().enabled = false;
	}

	void Update () {
		if (Score.gameOver) {
			GetComponent<Text> ().enabled = true;
		}
	}
}
