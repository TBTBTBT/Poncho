using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OpeningManager : MonoBehaviour {
	public List<Sprite> images;
	public List<string> texts;
	public Image view;
	public Text text;
	int nowPage = 0;
	public string sceneName;
	// Use this for initialization
	void Start () {
		EventManager.OnTouchBegin.AddListener (GoNextPage);
		GoNextPage(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GoNextPage(int num){
		if (!NextPage (num)) {
			SceneManager.LoadScene (sceneName);
		}
	}
	bool NextPage(int num){
		if (num == 0) {
			if (images.Count > nowPage) {
				if(images [nowPage])view.sprite = images[nowPage];
				if(texts.Count > nowPage)text.text = texts[nowPage];
				nowPage++;
				return true;
			}

		}
		return false;
	}
}
