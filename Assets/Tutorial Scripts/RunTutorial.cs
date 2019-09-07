using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTutorial : MonoBehaviour {

	public static bool runningTutorial;
	public static float t;


	void Start () {
		//true when running tutorial
		runningTutorial = true;
		t = Time.time;
	}
	

}
