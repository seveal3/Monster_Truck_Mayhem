using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//spawns all enemy vehicles and hazards

	private GameObject carHazard;
	private Vector3 spawnValues;
	private int[] posArray = new int[] { -15, 0, 15 };
	private float[] timeArray = new float[] {0.75f, 0.75f, 1, 1, 1.25f, 0.9f}; 
	private int[] multiple = new int[] {1,1,1,2};
	private string[] prefabsArray = new string[]{"Taxi", "Car_Red", "Car_Blue", "Bus_Yellow", "Bus_Green", "Barrier", "Blockade" };
	private int posx;
	private int posxb;
	private bool single;
	public static bool running;

	void Start(){
		StartCoroutine(SpawnWaves ());
		running = true;
		RunTutorial.runningTutorial = false;
	}

	//controls vehicles/hazards random spawning
	//sets delay times between spawns
	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds (0.5f);

		while(running){

			int mult = Random.Range (0,4);
			if (1 == multiple [mult]) {
				spawnSingle ();
			}
			else{
				spawnDouble ();
			}

			int delay = Random.Range (0, 6);

			if (!TextureFade.prePolice && carHazard.name != "Blockade") {
				yield return new WaitForSeconds (timeArray[delay]);
			}
			if (!TextureFade.prePolice && carHazard.name == "Blockade") {
				yield return new WaitForSeconds (1.25f);
			}
			if(TextureFade.prePolice) {
				yield return new WaitForSeconds (2.5f);
			}
		}
	}

	//spawns two objects side by side
	void spawnDouble(){
		int prefab = Random.Range (0, 6);
		carHazard = Resources.Load (prefabsArray[prefab]) as GameObject;
		posx = Random.Range (0, 3);
		spawn (carHazard, posx);

		prefab = Random.Range (0, 6);
		carHazard = Resources.Load (prefabsArray[prefab]) as GameObject;

		do {
			posxb = Random.Range (0, 3);
		} while (posxb == posx);

		spawn (carHazard, posxb);
	}

	//spawns a single object
	void spawnSingle(){

		if (TextureFade.police) {
			int prefab = Random.Range (0, 7);
			carHazard = Resources.Load (prefabsArray[prefab]) as GameObject;
		}

		if (!TextureFade.police) {
			int prefab = Random.Range (0, 6);
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

	//spawns an object
	void spawn(GameObject g, int pos){

		spawnValues.x = posArray [pos];
		spawnValues.y = g.transform.position.y;
		spawnValues.z = 55f; 
		Vector3 spawnPosition = spawnValues;

		Quaternion spawnRotation = g.transform.rotation;
		Instantiate (g, spawnPosition, spawnRotation);
	}
}
