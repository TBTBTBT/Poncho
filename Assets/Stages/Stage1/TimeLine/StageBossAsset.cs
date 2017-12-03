using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

[System.Serializable]
public class StageBossAsset: PlayableAsset
{
	public GameObject boss;
	public Vector2 pos;
	public override Playable CreatePlayable(PlayableGraph graph, GameObject go) {
		//Instantiate (enemy, spawn, Quaternion.identity);
		var n = new BossManager();
		n.BossPrefab = boss;
		n.pos = pos;
		//n.TalkSet = TalkSet;
		//n.left = left;
		//n.right = right;
		//n.text = text;
		return ScriptPlayable<BossManager>.Create(graph,n);

	}
}
