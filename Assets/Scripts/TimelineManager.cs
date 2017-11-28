using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
[System.Serializable]
public class Talk{
	public Sprite left;
	public Sprite right;
	public string text;
	public Talk(){
	}
	public Talk(string s,Sprite l,Sprite r){
		text = s;
		left = l;
		right = r;
	}
}
public class TimelineManager : MonoBehaviour {
	public List<Talk> Talk;// = new List<Talk> ();
	public GameObject TalkSet;
	public Image left;
	public Image right;
	public Text text;
	int nowPage = 0;
	PlayableDirector pd;
	// Use this for initialization
	void Start () {
		pd = GetComponent<PlayableDirector> ();
		EventManager.OnTouchBegin.AddListener (GoNextPage);
		GoNextPage (0);
		StartCoroutine (Fade(new Vector2 (0, 0)));
	}
	void GoNextPage(int num){
		if (!NextPage (num)) {
			StartCoroutine (Fade(new Vector2 (0, -400)));
			pd.Play();
		}
	}
	bool NextPage(int num){
		if (num == 0) {
			if (Talk.Count > nowPage) {
				if(Talk [nowPage].left)left.sprite = Talk [nowPage].left;
				if(Talk [nowPage].right)right.sprite = Talk [nowPage].right;
				text.text = Talk [nowPage].text;
				nowPage++;
				return true;
			}

		}
		return false;
	}
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Fade(Vector2 pos){
		for (int i = 0; i < 30; i++) {
			TalkSet.transform.localPosition = Vector2.Lerp (TalkSet.transform.localPosition,pos,Time.deltaTime*10);
			yield return new WaitForSeconds (0.01f);
		}
	}
}
