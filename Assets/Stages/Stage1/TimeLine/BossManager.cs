using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class BossManager : PlayableBehaviour
{
	public PlayableDirector thisDirector;
	GameObject Boss;
	public GameObject BossPrefab;
	public Vector2 pos;
	bool isInit = false;
	// Called when the owning graph starts playing
	public override void OnGraphStart(Playable playable) {
		
	//	
	}

	// Called when the owning graph stops playing
	public override void OnGraphStop(Playable playable) {
		
	}

	// Called when the state of the playable is set to Play
	public override void OnBehaviourPlay(Playable playable, FrameData info) {
		if (!isInit) {
			thisDirector = GameObject.Find ("StageManager").GetComponent<PlayableDirector> ();

			if (thisDirector) {
				thisDirector.Pause ();
				Boss = GameObject.Instantiate (BossPrefab, pos, Quaternion.identity);
			}
			isInit = true;
		}

	}

	// Called when the state of the playable is set to Paused
	public override void OnBehaviourPause(Playable playable, FrameData info) {
		
	}

	// Called each frame while the state is set to Play
	public override void PrepareFrame(Playable playable, FrameData info) {
		
	}

}
