using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

[System.Serializable]
public class StageTalkAsset: PlayableAsset
{
	//public PlayableDirector thisDirector;
	public List<Talk> Talk;
	//public GameObject TalkSet;
	//public Image left;
	//public Image right;
	//public Text text;
	// Factory method that generates a playable based on this asset
	public override Playable CreatePlayable(PlayableGraph graph, GameObject go) {
		//Instantiate (enemy, spawn, Quaternion.identity);
		var n = new TalkManager();
		n.Talk = Talk;
		//n.TalkSet = TalkSet;
		//n.left = left;
		//n.right = right;
		//n.text = text;
		return ScriptPlayable<TalkManager>.Create(graph,n);

	}
}
