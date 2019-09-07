using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroy : MonoBehaviour {

	//destroys an object when it goes off the screen
	void OnTriggerExit(Collider other) {
		Destroy (other.gameObject);
	}
}
