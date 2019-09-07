using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBarImage : MonoBehaviour {
	//disables score bar on game over

	void Start () {
		GetComponent<Image> ().enabled = true;
	}


	void Update () {
		if (Score.gameOver && (HazardScript.t > 1f || CarScript.t > 1f)) {
			GetComponent<Image> ().enabled = false;
		}
	}
}
