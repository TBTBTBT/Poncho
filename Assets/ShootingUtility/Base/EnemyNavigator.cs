using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigator : MonoBehaviour {
	public AnimationCurve x;
	public AnimationCurve y;
	Vector2 position;
	float time = 0;
	[System.NonSerialized]
	public bool turnY = false;
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += speed;
		if(!turnY)transform.position = position + new Vector2(x.Evaluate (time),y.Evaluate(time));
		if( turnY)transform.position = position + new Vector2(x.Evaluate (time), - y.Evaluate(time));
	}
}
