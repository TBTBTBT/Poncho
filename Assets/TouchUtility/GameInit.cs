using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameInit : MonoBehaviour {

	[RuntimeInitializeOnLoadMethod]
	static void Initialize()
	{
		Application.targetFrameRate = 60;
		//SceneManager.LoadScene("Manager",LoadSceneMode.Additive);
	}
}
