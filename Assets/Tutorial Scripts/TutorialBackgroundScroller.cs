using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBackgroundScroller : MonoBehaviour {

	//controls road speed for tutorial

	public static float scrollSpeed;
	public float tileLength;
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
		scrollSpeed = -70;
	}

	void Update () {
		float y = Mathf.Repeat (Time.time * scrollSpeed, tileLength);
		transform.position = startPosition + Vector3.forward * y;
	}
}
