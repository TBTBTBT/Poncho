using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class TalkManager : PlayableBehaviour
{
	public PlayableDirector thisDirector;
	public List<Talk> Talk;
	public GameObject TalkSet;
	public Image left;
	public Image right;
	public Text text;
	int nowPage = 0;
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
			TalkSet = GameObject.Find ("TalkSet");
			left = TalkSet.transform.Find ("Left").GetComponent<Image> ();
			right = TalkSet.transform.Find ("Right").GetComponent<Image> ();
			text = TalkSet.transform.Find ("Talk").GetComponent<Text> ();
			if (thisDirector) {
				thisDirector.Pause ();
				EventManager.OnTouchBegin.AddListener (GoNextPage);

				GoNextPage (0);
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
	void GoNextPage(int num){
		if (!NextPage (num)) {
			//StartCoroutine (Fade(new Vector2 (0, -400)));
			Debug.Log ("remove");
			EventManager.OnTouchBegin.RemoveListener (GoNextPage);
			thisDirector.Play();
		}
	}
	bool NextPage(int num){
		if (num == 0) {
			Debug.Log (TalkSet);
			if (Talk.Count > nowPage) {
				if (Talk[nowPage].left)
				{
					left.sprite = Talk[nowPage].left;
					left.gameObject.SetActive(true);
				}
				else
				{
					left.gameObject.SetActive(false);
				}
				if (Talk[nowPage].right)
				{
					right.sprite = Talk[nowPage].right;
					right.gameObject.SetActive(true);
				}
				else
				{
					right.gameObject.SetActive(false);
				}
				text.text = Talk [nowPage].text;
				nowPage++;
				return true;
			}

		}
		return false;
	}
}
