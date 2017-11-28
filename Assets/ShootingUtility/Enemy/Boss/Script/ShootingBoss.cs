using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBoss :  ShootingEnemyBase {
	TickEvent span40;
	TickEvent span600;
	int mode = 0;
	// Use this for initialization
	protected override void Init(){
		span40 = new TickEvent (40);
		span40.SetFunction (Attack);
		span600 = new TickEvent (600);
		span600.SetFunction (ChangeAttack);
	}
	void ChangeAttack(){
		mode++;
	}
	// Update is called once per frame
	protected override void FixedUpdateLate()
	{
		span40.Invoke ();
		span600.Invoke ();
	}
	void Attack(){
		if (mode == 0) {
			Shot ();
		}
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
