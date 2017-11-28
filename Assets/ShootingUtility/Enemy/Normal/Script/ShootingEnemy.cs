using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : ShootingEnemyBase {
	TickEvent span20;
	// Use this for initialization
	protected override void Init(){
		span20 = new TickEvent (20);
		span20.SetFunction (Shot);
	}
	
	// Update is called once per frame
	protected override void FixedUpdateLate()
	{
		span20.Invoke ();
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
