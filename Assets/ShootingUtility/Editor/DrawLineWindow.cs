using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DrawLineWindow : EditorWindow{

	[MenuItem("Shooting/Navigater")]
	static void Init(){
		EditorWindow.GetWindowWithRect<DrawLineWindow>(new Rect(0,0,300,300));
	}
	bool showBtn = false;
	void OnGUI(){
		//showBtn = EditorGUILayout.Toggle("Show Button", showBtn);
		//EditorGUILayout.LabelField ("Mouse Position: ", Event.current.mousePosition.ToString ());
		//if (Event.current.type == EventType.MouseMove)
			//Repaint ();
		//Debug.Log ("omoi");

		//Handles.DrawBezier(new Vector3(0,0,0),new Vector3(100,100,0),Event.current.mousePosition,new Vector3(0,0,0), Color.green, null, 3f);
	}
}
