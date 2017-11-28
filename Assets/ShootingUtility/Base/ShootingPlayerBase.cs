using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ShootingPlayerBase : UtilityBehaviour
{
    protected Rigidbody2D rigidbody;
    protected Vector2 input;   //方向キー入力を保存
    protected int button1 = 0;
    protected int button2 = 0;
    [Header("自機の速さ")]
    public float speed = 1;
    [Header("弾を設定")]
    public GameObject bullet;
    [Header("HP")]
    public int hp = 1;
    delegate void callBack();
    delegate void callBack2(int msg);
    //最初に一回だけ実行
    void Start()
    {
        transform.tag = "Player";
        rigidbody = GetComponent<Rigidbody2D>();
        Init();

		//スマホ版
		EventManager.OnTouchBegin.AddListener(TouchBegin);
		EventManager.OnTouchMove.AddListener(TouchBegin);
		EventManager.OnTouchEnd.AddListener(TouchEnd);


    }
	#region smartDevice
	Vector2? beforetouch = null;
	bool isTouch=false;
	void TouchBegin(int num){
		if (num == 0) {
			if (beforetouch!= null) {
				Vector2 newpos = TouchManager.Instance.GetTouchWorldPos(num);
				transform.position += (Vector3)(newpos - beforetouch) * 1.5f;
			}
			beforetouch = TouchManager.Instance.GetTouchWorldPos(num);
			isTouch = true;
		}
		TouchLate ();
	}
	void TouchEnd(int num){
		if (num == 0) {
			beforetouch = null;
			isTouch = false;
		}
	}
	#endregion
    public void Damage()
    {
        hp--;
        if(hp<=0)
        Destroy(gameObject);
    }
	protected virtual void TouchLate()
	{
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
            g.GetComponent<ShootingBulletBase>().Set(angle,transform.position);
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
        //入力処理

		//PCばん

        //InputAxis();
        //InputButton(ref button1, Input.GetKey(KeyCode.Z), StartPushButton1, UpdatePushButton1, EndPushButton1);
        //InputButton(ref button2, Input.GetKey(KeyCode.X), StartPushButton2, UpdatePushButton2, EndPushButton2);
        
		//スマホ版

		InputButton(ref button1, isTouch, StartPushButton1, UpdatePushButton1, EndPushButton1);

        UpdateLate();
        
    }
    void FixedUpdate()
    {
		//PCばん
		//Move();

    }
    void Move()
    {
        rigidbody.velocity = input * speed;
    }
    void InputAxis()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void InputButton(ref int button, bool isPush,callBack start,callBack2 upd,callBack end)
    {
        if (isPush)
        {
            if (button == 0) start();
            else upd(button);
            button++;
        }
        else
        {
            end();
            button = 0;
        }
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
    protected virtual void StartPushButton1()
    {

    }
    protected virtual void UpdatePushButton1(int button)
    {

    }
    protected virtual void EndPushButton1()
    {

    }
    protected virtual void StartPushButton2()
    {

    }
    protected virtual void UpdatePushButton2(int button)
    {

    }
    protected virtual void EndPushButton2()
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
