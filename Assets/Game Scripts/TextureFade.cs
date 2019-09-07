using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureFade : MonoBehaviour {

	//controls the background texture for periods of police, prepolice and standard gameplay

	public float duration;
	public Renderer rend;
	public static bool police;
	public static bool prePolice;
	private bool called;
	private Material standardMat;
	private Material blendMat;
	private float t;
	private float waveLength;

	void Start(){
		rend = gameObject.GetComponent<Renderer>();
		standardMat = Resources.Load ("StandardMat") as Material;
		blendMat = Resources.Load ("BlendMat") as Material;
		police = false;
		called = false;
		t = Time.time;
		waveLength = Random.Range (15, 25);
	}

	void Update() {

		//sets standard texture if the game is over
		if (Score.gameOver) {
			rend.material = standardMat;
			police = false;
			called = false;
		}
			
		if (!Score.gameOver) {
			if (police) {
				//sets blend texture when police
				if (Time.time < t + 10 && !called) {
					rend.material = blendMat;
					called = true;
				}
				if (Time.time < t + 10 && called) {
				//ping pongs between colours
					float lerp = Mathf.PingPong(Time.time, duration) / duration;
					rend.material.SetFloat ("_Blend", lerp);
				}

				if (Time.time > t + 10) {
					t = Time.time;
					//sets random length of time before next police section
					waveLength = Random.Range (15, 25);
					police = false;
					called = false;
				}
			}

			//sets period of non-police time
			if (!police && !prePolice) {
				if (Time.time < t + waveLength) {
					rend.material = standardMat;
				}

				if (Time.time > t + waveLength) {
					t = Time.time;
					prePolice = true;
				}
			}

			//2 seconds of pre police without vehicles or hazards
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
	}
}