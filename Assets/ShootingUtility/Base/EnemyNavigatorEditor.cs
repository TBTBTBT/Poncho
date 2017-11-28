using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
#if UNITY_EDITOR
using UnityEditor;
#endif*/
//[ExecuteInEditMode]
public class EnemyNavigatorEditor : MonoBehaviour {
	public List<Vector2> point = new List<Vector2>();
	// Use this for initialization

	// Update is called once per frame
	/*
	void OnDrawGizmos (){
		//Debug.Log (Event.current.type);
		//if(Event.current == null || Event.current.type != EventType.mouseUp){
	//		return;
		//}
		//Debug.Log (Event.current.type);
		Event e = Event.current;

		if (Event.current.clickCount > 0) {
			foreach(GameObject go in Selection.gameObjects)
			{
				
				if (this.gameObject.name == go.name) {
					Debug.Log("TRUE");
					break;
				}
			}
			Debug.Log (Event.current);
			Vector3 mousePosition = Event.current.mousePosition * 2;

			//シーン上の座標に変換
			mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;
			mousePosition   = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);

			Debug.Log (mousePosition);
		point.Add (mousePosition);


		}
		for (int i = 0; i < point.Count; i++) {
			//Handles.DrawBezier (transform.position, new Vector3 (0, 0, 0), Event.current.mousePosition, new Vector3 (0, 0, 0), Color.green, null, 3f);
			if (i > 0)
				Handles.DrawLine (point [i - 1], point [i]);
			if (i == 0)
				Handles.DrawLine (transform.position, point [i]);
		}
	}*/
}
