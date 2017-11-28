using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : ShootingBulletBase
{
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

}
