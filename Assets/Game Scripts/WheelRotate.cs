﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (!Score.gameOver) {
			transform.Rotate (0, 0, 180 * Time.deltaTime);
		}
	}
}
