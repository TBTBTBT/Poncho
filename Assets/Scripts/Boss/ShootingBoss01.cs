using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBoss01 : ShootingEnemyBase {
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;
    TickEvent spanEv;
    // Use this for initialization
    protected override void Init() {
        spanEv = new TickEvent(120);
        spanEv.SetFunction(Shot01);
    }

    // Update is called once per frame
    protected override void UpdateLate () {
        spanEv.Invoke();
	}
	void Shot01(){
        StartCoroutine("Attack02");
	}
	IEnumerator Attack01(){
        float radius = 360;
        bool isAim = false;
        int num = 20;
        for (int i = 0;i < num; i++)
        {
            float rad = -(radius / 2) + ((radius / (float)num) / 2) + (float)i * (radius / (float)num);
            GameObject go = Instantiate(bullet1, transform.position, Quaternion.identity);
            go.GetComponent<ShootingBulletBase>().Set(rad, transform.position, isAim);
            yield return new WaitForSeconds(0.02f);
        }
	}
    IEnumerator Attack02()
    {
        float radius = 360;
        bool isAim = false;
        int num = 20;
        for (int i = 0; i < num; i++)
        {

            for (int j = 0; j <2; j++)
            {
                GameObject go = Instantiate(bullet1, transform.position, Quaternion.identity);
                go.GetComponent<ShootingBulletBase>().Set(180, transform.position-new Vector3(0,0.5f - 1 * j,0), false);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
