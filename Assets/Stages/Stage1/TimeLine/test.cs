using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class test : PlayableBehaviour
{
	public GameObject enemy;
	public Vector2 spawn;
	public float span;
	public bool turnY;
	float t = 0;
	// Called when the owning graph starts playing
	public override void OnGraphStart(Playable playable) {
		
	//	
	}

	// Called when the owning graph stops playing
	public override void OnGraphStop(Playable playable) {
		
	}

	// Called when the state of the playable is set to Play
	public override void OnBehaviourPlay(Playable playable, FrameData info) {
		
		GameObject go = GameObject.Instantiate (enemy, spawn, Quaternion.identity);
		if (go.GetComponent<EnemyNavigator> ()) {
			go.GetComponent<EnemyNavigator> ().turnY = turnY;
		}
	}

	// Called when the state of the playable is set to Paused
	public override void OnBehaviourPause(Playable playable, FrameData info) {
		
	}

	// Called each frame while the state is set to Play
	public override void PrepareFrame(Playable playable, FrameData info) {
	/*	if (t > span) {
			GameObject.Instantiate (enemy, spawn, Quaternion.identity);
			t = 0;
		}
		t+=info.deltaTime;*/
		//Debug.Log (info.deltaTime);
	}
}
