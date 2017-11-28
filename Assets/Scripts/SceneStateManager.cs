using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneStateManager : SingletonMonoBehaviour<SceneStateManager> {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("Title");
	//	StartCoroutine (AddScene ("Title"));
	}/*
	IEnumerator AddScene(string name)
	{
		SceneManager.LoadScene( name );
		Scene scene = SceneManager.GetSceneByName(name);
		while ( !scene.isLoaded )
		{
			yield return null;
		}
		//指定したシーン名をアクティブにする
		SceneManager.SetActiveScene( scene );
	}*/
	// Update is called once per frame
	void Update () {
		
	}
}
