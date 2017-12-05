using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : ShootingBulletBase
{
	float angle = 0;
	public GameObject looks;
    protected override void OnHitEnemy(ShootingEnemyBase enemy)
    {
       // Destroy(player.gameObject);
		enemy.Damage();
		Hit ();
    }
    protected override void OnHitPlayer(ShootingPlayerBase player)
    {

        player.Damage();
		Hit ();
    }
	protected override void UpdateLate(){
		angle += 20;
		if(looks)looks.transform.localRotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
		if(Mathf.Abs(transform.localPosition.x) > 2.8f || Mathf.Abs(transform.localPosition.y) > 1.6f){
			Destroy(this.gameObject);
		}
	}

}
