using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy03 : ShootingEnemyBase {
	TickEvent spanEv;
    ShootingPlayerBase player;
    public int span = 0;
    public float radius = 360;
    public int bulletNum = 10;
	public bool isShotAimPlayer = true;
	// Use this for initialization
	protected override void Init(){
		spanEv = new TickEvent (span);
		spanEv.SetFunction (Shot);
        if(GameObject.FindGameObjectWithTag("Player")){

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingPlayerBase>();
        }
    }
	
	// Update is called once per frame
	protected override void FixedUpdateLate()
	{
		spanEv.Invoke ();
	}
	void ShotOne(bool isAim,int num,float radius)
    {
		
        if (bullet)
        {
			for (int i = 0; i < num; i++) {
				float rad = -(radius/2) +((radius/(float)num)/2) + (float)i * (radius/(float)num);
				GameObject go = Instantiate (bullet, transform.position, Quaternion.identity);
				go.GetComponent<ShootingBulletBase> ().Set (rad, transform.position, isAim);
			}
        }

        else
        {
            Debug.LogError("弾をセットしてください");
        }
    }
	protected override void Shot()
	{
		ShotOne (isShotAimPlayer, bulletNum, radius);
	}
    float AimPlayer(Vector2 pos)
    {
        if (player)
        {
            return GetAim(pos, player.transform.position);
            //transform.localRotation = Quaternion.AngleAxis(direction - 90, new Vector3(0, 0, 1));
        }
        return 0;
    }
}
