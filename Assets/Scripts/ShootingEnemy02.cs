using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy02 : ShootingEnemyBase {
	TickEvent spanEv;
	public int span = 0;
	// Use this for initialization
	protected override void Init(){
		spanEv = new TickEvent (span);
		spanEv.SetFunction (Shot);
	}
	
	// Update is called once per frame
	protected override void FixedUpdateLate()
	{
		spanEv.Invoke ();
	}
	protected override void Shot()
	{
		if(bullet){
			GameObject go = Instantiate(bullet,transform.position,Quaternion.identity);
			go.GetComponent<ShootingBulletBase>().Set(0,transform.position);
		}
		
		else
		{
			Debug.LogError("弾をセットしてください");
		}
	}
}
