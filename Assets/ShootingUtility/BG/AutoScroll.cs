using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour {
	public bool isSideScroll;
	public float speed = 1;
	public float limit = 1;
	Vector3 startPos;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		if (isSideScroll)
			transform.position += new Vector3 (speed, 0,0);
		else transform.position += new Vector3(0,speed,0);
		if (speed > 0) {
			if (transform.position.x > limit) {
				if (isSideScroll)
					transform.position -= new Vector3 ((limit - startPos.x), 0, 0);
				else
					transform.position -= new Vector3 (0, (limit - startPos.x), 0);
			}
		} else {
			if (transform.position.x < limit) {
				if (isSideScroll)
					transform.position -= new Vector3 ((limit - startPos.x), 0, 0);
				else
					transform.position -= new Vector3 (0, (limit - startPos.x), 0);
			}
		}
	}
}
