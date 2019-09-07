using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGameController : MonoBehaviour {

	//controls the waves of vehicles/hazards for the tutorial

	private GameObject carHazard;
	private Vector3 spawnValues;
	private int[] posArray = new int[] { -15, 0, 15 };
	private float[] timeArray = new float[] {0.75f, 0.75f, 1, 1, 1.25f, 0.5f}; 
	private int[] multiple = new int[] {1,1,1,2};
	private string[] prefabsArray = new string[]{"Taxi", "Car_Red", "Car_Blue", "Bus_Yellow", "Bus_Green", "Barrier", "Blockade" };
	private int posx;
	private int posxb;
	private bool single;
	public static bool tutorialComplete;

	private int wave;
	private Coroutine b;


	void Start(){
		tutorialComplete = false;
		b = StartCoroutine(Wave ());
	}

	IEnumerator Wave(){

		yield return new WaitForSeconds (10f);


		wave = 5;
		int i = 0;

		while (i < 5) {
			int mult = Random.Range (0,4);

			spawnSingle ();

			yield return new WaitForSeconds (2.5f);

			i++;
		}

		yield return new WaitForSeconds (3.0f);

		spawn ((Resources.Load ("Barrier") as GameObject), 1);

		yield return new WaitForSeconds (3.0f);

		wave = 6;

		i = 0;

		while (i < 5) {
			int mult = Random.Range (0,4);
			spawnSingle ();
			yield return new WaitForSeconds (1f);
			i++;
		}

		TutorialTextFade.t = Time.time;
		TutorialTextFade.prePolice = true;

		yield return new WaitForSeconds (10.0f);

		i = 0;

		while (i < 5 && TutorialTextFade.police) {
			int mult = Random.Range (0,4);
			spawnSingle ();
			yield return new WaitForSeconds (1f);
			i++;
		}

		yield return new WaitForSeconds (4.0f);

		spawn ((Resources.Load ("Blockade") as GameObject), 1);

		wave = 7;

		while (i < 5 && TutorialTextFade.police) {
			int mult = Random.Range (0,4);
			spawnSingle ();
			yield return new WaitForSeconds (1f);
			i++;
		}

		yield return new WaitForSeconds (4f);

		tutorialComplete = true;
	}

	void Update(){
		if (Score.gameOver || tutorialComplete) {
			StopCoroutine (b);
		}
	}

	void spawnDouble(){
		int prefab = Random.Range (0, wave);
		carHazard = Resources.Load (prefabsArray[prefab]) as GameObject;
		posx = Random.Range (0, 3);
		spawn (carHazard, posx);

		prefab = Random.Range (0, wave);
		carHazard = Resources.Load (prefabsArray[prefab]) as GameObject;

		do {
			posxb = Random.Range (0, 3);
		} while (posxb == posx);

		spawn (carHazard, posxb);
	}

	void spawnSingle(){

		if (TextureFade.police) {
			int prefab = Random.Range (0, wave);
			carHazard = Resources.Load (prefabsArray[prefab]) as GameObject;
		}

		if (!TextureFade.police) {
			int prefab = Random.Range (0, wave);
			carHazard = Resources.Load (prefabsArray[prefab]) as GameObject;
		}

		if (carHazard.name == "Blockade") {
			posx = Random.Range (0, 2);
		}
		else{
			posx = Random.Range (0, 3);
		}

		spawn (carHazard, posx);
	}

	void spawn(GameObject g, int pos){

		spawnValues.x = posArray [pos];
		spawnValues.y = g.transform.position.y;
		spawnValues.z = 55f; 
		Vector3 spawnPosition = spawnValues;

		Quaternion spawnRotation = g.transform.rotation;
		Instantiate (g, spawnPosition, spawnRotation);
	}
}
