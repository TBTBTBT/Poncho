using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityBehaviour : MonoBehaviour {
	public void Pause(){
	}
	public float GetAim(Vector2 p1, Vector2 p2)
	{
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		float rad = Mathf.Atan2(dy, dx);
		Debug.Log(rad);
		return rad * Mathf.Rad2Deg;
	}
}
public class TickEvent{
	public delegate void callBack ();
	List<callBack> c = new List<callBack>();
	int max = 0;
	int time = 0;
	public TickEvent(int tick){
		max = tick;
	}
	public void SetSpan(int t){
		max = t;
	}
	public void SetFunction(callBack cb){
		c.Add (cb);
	}
	public void Reset (){
		time = 0;
	}
	public void Invoke(){
		time++;
		if (time >= max) {
			time = 0;
			foreach (callBack cb in c) {
				cb ();
			}
		}
	}
}