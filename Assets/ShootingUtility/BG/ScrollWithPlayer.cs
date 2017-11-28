using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWithPlayer : MonoBehaviour {
	Vector3 start;
	public float scale = 0.5f;
	// Use this for initialization
	void Start () {
		start = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject p;
		if (p = GameObject.FindGameObjectWithTag ("Player"))
			transform.position = new Vector3 (transform.position.x, start.y -p.transform.position.y * scale, transform.position.z);
	}
}
