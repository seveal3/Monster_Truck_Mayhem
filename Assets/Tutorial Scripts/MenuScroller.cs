using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScroller : MonoBehaviour {

	//sets background scroll speed for menu

	public static float scrollSpeed;
	public float tileLength;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		scrollSpeed = -40;
	}

	// Update is called once per frame
	void Update () {
		float y = Mathf.Repeat (Time.time * scrollSpeed, tileLength);
		transform.position = startPosition + Vector3.forward * y;
	}
}
