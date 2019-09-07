using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextFade : MonoBehaviour {

	//controls the police, prepolice and standard periods during the tutorial

	public float duration;
	public Renderer rend;
	public static bool police;
	public static bool prePolice;
	private bool called;
	private Material standardMat;
	private Material blendMat;
	public static float t;

	void Start(){
		rend = gameObject.GetComponent<Renderer>();
		standardMat = Resources.Load ("StandardMat") as Material;
		blendMat = Resources.Load ("BlendMat") as Material;
		prePolice = false;
		police = false;
		called = false;
		t = Time.time;
	}

	void Update() {
		if (!Score.gameOver) {
			if (police) {
				if (Time.time < t + 20 && !called) {
					rend.material = blendMat;
					called = true;
				}
				if (Time.time < t + 20 && called) {
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					rend.material.SetFloat ("_Blend", lerp);
				}

				if (Time.time > t + 20) {
					police = false;
					called = false;
				}
			}

			if (!police && !prePolice) {
				rend.material = standardMat;
			}

			if(prePolice){
				if (Time.time < t + 2) {
					rend.material = standardMat;
				}

				if (Time.time > t + 2) {
					t = Time.time;
					prePolice = false;
					police = true;
				}
			}
		}

		if (Score.gameOver) {
			rend.material = standardMat;
		}
	}
}