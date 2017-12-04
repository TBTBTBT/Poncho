using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : ShootingPlayerBase {
    
    //使用できる特別な関数
    //Shot(); ... 弾を撃つ
    //

    //Startの代わり
    protected override void Init()
    {

    }
    //Updateの代わり
    protected override void UpdateLate()
    {
		Limit ();
    }
	protected override void TouchLate()
	{
		Limit ();
	}
	void Limit(){
		//new Vector2 l = new Vector2(0,0);
		if (Mathf.Abs (transform.position.x) > 2.5f) {
			transform.position = new Vector2(2.5f * Mathf.Sign (transform.position.x),transform.position.y);
		}
		if (Mathf.Abs (transform.position.y) > 1.5f) {
			transform.position = new Vector2(transform.position.x,1.5f * Mathf.Sign (transform.position.y));
		}
	}
    protected override void Shot()
    {
		//for (int i = 0; i < 19; i++) {
		//	Shot(-i * 10);
		//}
		Shot2(0,new Vector2(0.01f,-0.1f));
		Shot2(0,new Vector2(0.01f,0.1f));
		Shot2(-30,new Vector2(0.01f,-0.1f));
		Shot2(30,new Vector2(0.01f,0.1f));
       // Shot(-45);
        //Shot(-135);
    }
	void Shot2(float angle,Vector2 pos)
	{
		if (bullet)
		{
			GameObject g = Instantiate(bullet, transform.position + (Vector3)pos, Quaternion.identity);
			g.GetComponent<ShootingBulletBase>().Set(angle,transform.position + (Vector3)pos);
		}
		else
		{
			Debug.LogError("弾をセットしてください");
		}
	}
    //-----------------------------------------------------
    //Zキーの処理
    //-----------------------------------------------------

    //ボタン入力開始時
    protected override void StartPushButton1()
    {
        Shot();
    }
    //ボタン入力継続時
    protected override void UpdatePushButton1(int button)
    {
        RapidShot(4);
    }
    //ボタン入力終了時
    protected override void EndPushButton1()
    {
        ReloadShot();
    }

    //-----------------------------------------------------
    //Xキーの処理
    //-----------------------------------------------------


    //ボタン入力開始時
    protected override void StartPushButton2()
    {

    }
    //ボタン入力継続時
    protected override void UpdatePushButton2(int button)
    {

    }
    //ボタン入力終了時
    protected override void EndPushButton2()
    {

    }
}
