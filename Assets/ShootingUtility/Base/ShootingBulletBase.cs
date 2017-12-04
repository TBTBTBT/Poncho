using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ShootingBulletBase : UtilityBehaviour {

    protected Rigidbody2D rigidbody;
    [Header("横スクロール")]
    public bool isSideScroll = false;
    [Header("プレイヤーの弾")]
    public bool isPlayer = false;

    [Header("最初にプレイヤーの方を向く")]
    public bool isLookPlayer = false;
    [Header("常にプレイヤーを追う")]
    public bool isAimPlayer = false;
    [Header("弾が消える時間")]
    public int MaxLifeTime = 100;
    [Header("スピード")]
    public float speed = 10;
    [Header("加速度")]
    public float accel = 0;
    //[Header("さらに、弾をセット")]
    //public GameObject bullet;
	[Header("ヒットエフェクト")]
	public GameObject hit;
    protected float direction;
    protected float lifeTime;
    ShootingPlayerBase player;
	// Use this for initialization
	void Awake () {
	//	Debug.Log(transform.position);

        rigidbody = GetComponent<Rigidbody2D>();

		if (GameObject.FindGameObjectWithTag ("Player")){
			
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<ShootingPlayerBase> ();
		}
		else {
			direction = isPlayer ? 0 : 180;
			if (isSideScroll) direction -= 90;
			transform.localRotation = Quaternion.AngleAxis(direction, new Vector3(0, 0, 1));
		}
        if (!isLookPlayer)
        {
            direction = isPlayer ? 0 : 180;
            if (isSideScroll) direction -= 90;
            transform.localRotation = Quaternion.AngleAxis(direction, new Vector3(0, 0, 1));
        }
        else AimPlayer(transform.position);
	}
    public void Set(float ang)
    {
        direction = ang;
        if (!isLookPlayer) transform.localRotation = Quaternion.AngleAxis(direction-90, new Vector3(0, 0, 1));
    }
	//unityのバグのせいでAwakeからpositionを取得できない
	public void Set(float ang,Vector2 pos)
	{
		direction = ang;
		transform.position = pos;
//		Debug.Log(transform.position);
		if (!isLookPlayer) transform.localRotation = Quaternion.AngleAxis(direction-90, new Vector3(0, 0, 1));
		else AimPlayer(transform.position);
	}
    public void Set(float ang, Vector2 pos,bool isAim)
    {
        direction = ang;
        transform.position = pos;
        isLookPlayer = isAim;
        //		Debug.Log(transform.position);
        if (!isLookPlayer) transform.localRotation = Quaternion.AngleAxis(direction - 90, new Vector3(0, 0, 1));
        else {
            AimPlayer(transform.position);
            direction += ang;
            transform.localRotation = Quaternion.AngleAxis(direction - 90, new Vector3(0, 0, 1));


        };
    }
    void AimPlayer(Vector2 pos){
        if (player)
        {
			//Debug.Log(pos);
            direction = GetAim(pos, player.transform.position);
            transform.localRotation = Quaternion.AngleAxis(direction - 90, new Vector3(0, 0, 1));
		//	Debug.Log(direction);
        }
    }
	// Update is called once per frame
    void FixedUpdate()
    {
        if (isAimPlayer) AimPlayer(transform.position);
		speed += accel;
		rigidbody.velocity = new Vector2(Mathf.Cos(direction*Mathf.PI/180),Mathf.Sin(direction*Mathf.PI/180))* speed;
        lifeTime++;
        if (lifeTime > MaxLifeTime)
        {
			Hit ();
        }
		UpdateLate ();
    }
	protected virtual void UpdateLate(){
	}
    protected virtual void OnHitEnemy(ShootingEnemyBase enemy)
    {

    }
    protected virtual void OnHitPlayer(ShootingPlayerBase player)
    {

    }
	protected void Hit(){
		if(hit)
		Instantiate (hit, transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
    void OnTriggerEnter2D(Collider2D c)
    {
        if (isPlayer)
        {
            ShootingEnemyBase e = c.GetComponent<ShootingEnemyBase>();
            if (e)
            {
                OnHitEnemy(e);
            }
            
        }
        else
        {
            ShootingPlayerBase p = c.GetComponent<ShootingPlayerBase>();
            if (p)
            {
                OnHitPlayer(p);
            }
        }
    }
}
