using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ShootingEnemyBase : UtilityBehaviour {

	protected Rigidbody2D rigidbody;
	protected Vector2 move;
	protected int button1 = 0;
	protected int button2 = 0;
	[Header("自機の速さ")]
	public float speed = 1;
	[Header("弾を設定")]
	public GameObject bullet;
	[Header("HP")]
	public int hp = 1;
	[Header("生存時間")]
	public int lifeTime = 100;
	delegate void callBack();
	delegate void callBack2(int msg);
	//最初に一回だけ実行
	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		Debug.Log (transform.position);
		Init();
		move = new Vector2 (0, 0);
	}
	public void Damage()
	{
		hp--;
		if(hp<=0)
			Destroy(gameObject);
	}
	protected virtual void Shot()
	{
		if(bullet)Instantiate(bullet,transform.position,Quaternion.identity);
		else
		{
			Debug.LogError("弾をセットしてください");
		}
	}
	protected virtual void Shot(float angle)
	{
		if (bullet)
		{
			GameObject g = Instantiate(bullet, transform.position, Quaternion.identity);
			g.GetComponent<ShootingBulletBase>().Set(angle);
		}
		else
		{
			Debug.LogError("弾をセットしてください");
		}
	}
	protected void Shot(Vector2 dir,float spd)
	{

	}

	//毎フレーム
	void Update()
	{
		
		UpdateLate();

	}
	void FixedUpdate()
	{
		Move();
		FixedUpdateLate ();
		lifeTime--;
		if (lifeTime < 0) {
			Destroy (this.gameObject);
		}
	}
	void Move()
	{
		rigidbody.velocity = move * speed;
	}
		
	void OnTriggerEnter2D(Collider2D c)
	{

	}
	protected virtual void Init()
	{

	}
	protected virtual void UpdateLate()
	{

	}
	protected virtual void FixedUpdateLate()
	{

	}
	int rapidtime = 0;
	protected void RapidShot(int span)
	{
		rapidtime++;
		if (rapidtime > span)
		{
			Shot();
			rapidtime = 0;
		}
	}
	protected void ReloadShot()
	{
		rapidtime = 0;
	}


}
