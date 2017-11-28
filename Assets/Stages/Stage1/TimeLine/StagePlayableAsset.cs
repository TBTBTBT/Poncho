using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class StagePlayableAsset : PlayableAsset
{
	public GameObject enemy;
	public Vector2 spawn;
	public float span;
	public bool turnY;
	// Factory method that generates a playable based on this asset
	public override Playable CreatePlayable(PlayableGraph graph, GameObject go) {
		//Instantiate (enemy, spawn, Quaternion.identity);
		var n = new test();
		n.spawn = spawn;
		n.enemy = enemy;
		n.span = span;
		n.turnY = turnY;
		return ScriptPlayable<test>.Create(graph,n);

	}
}
