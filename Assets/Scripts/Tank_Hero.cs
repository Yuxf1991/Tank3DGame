using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Hero : MonoBehaviour {
	public GameObject HeroBullet;
	public GameObject FireFlame;
	private Rigidbody TankRb;
	AudioSource GunSound;

    public GameObject GameControl;

	public float FlameLiveTime = 0.05f;
	public float MoveSpeed = 20.0f;
	public float AngleSpeed = 30.0f;
	public float MaxSpeed = 30.0f;
	public float FSpeed = 3;
	float BulletRate = 0.0f;
	private float BulletSpeedLevel = 200;
	public float SpeedLevel1, SpeedLevel2, SpeedLevel3, SpeedLevel4, SpeedLevel5;
	private float MoveHead=0;
	private int SpeedLevel = 1;
	public float Back;
	private float FBack;
	private float ShotRotation;
    public int BulletNumber;
    public int BulletNumberMax;

	public float ATN = 100.0f;
	public float Damage = 10.0f;
	public float Sunder = 0.08f;

	// Use this for initialization
	void Start () {
		TankRb = GetComponent<Rigidbody>();
		ShotRotation = 0.0f;
        BulletNumber = 40;
        BulletNumberMax = 40;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q) && ShotRotation < 90)
		{
			ShotRotation += 0.1f;
		}
		if (Input.GetKey(KeyCode.E) && ShotRotation > 0) {
			ShotRotation -= 0.1f;

		}
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			BulletSpeedLevel = SpeedLevel1;
			SpeedLevel = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			BulletSpeedLevel = SpeedLevel2;
			SpeedLevel = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			BulletSpeedLevel = SpeedLevel3;
			SpeedLevel = 3;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			BulletSpeedLevel = SpeedLevel4;
			SpeedLevel = 4;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			BulletSpeedLevel = SpeedLevel5;
			SpeedLevel = 5;
		}

		//主坦克行动及加速
		float temp1 = MoveSpeed, temp2 = MaxSpeed;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
		{
			temp1 *= FSpeed;
			temp2 *= FSpeed;
		} 
		else 
		{
		}


		Vector3 direction = Input.GetAxis("Vertical") * transform.forward;
		this.transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * AngleSpeed, 0, Space.World);
		if (Mathf.Sqrt(TankRb.velocity.sqrMagnitude) < temp2)
		{
			TankRb.AddForce(direction.normalized * temp1, ForceMode.VelocityChange);
			//this.transform.Translate(direction.normalized * temp1);
		}



		//旋转视角i 
		//Vector3 head_direction = Input.GetAxis("Mouse X") * transform.up;
		transform.Find("tower").transform.Rotate(0, 0, Input.GetAxis("Mouse X"), Space.Self);

		//如果翻车，则重置

		//每隔0.2s发射子弹
		BulletRate -= Time.deltaTime;
		bool flag = true;
		if (BulletRate <= 0 && BulletNumber > 0)
		{
			BulletRate = 0.05f;
			if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && flag)
			{
				flag = false;
				//发射子弹        
				GameObject go = (GameObject)Instantiate(HeroBullet);   
				go.transform.position = transform.Find("tower").transform.Find("Shoot").transform.position;
				go.transform.rotation = transform.Find("tower").transform.Find("Shoot").transform.rotation;
				go.transform.Rotate(0, 90, 0);

				go.SendMessage("SetSpeed", BulletSpeedLevel);
				Vector3 BP = new Vector3(ATN, Damage, Sunder);//用一个数组把子弹威力装起来
				go.SendMessage ("BulletPower", BP);

				go.transform.Rotate(0, 0, -ShotRotation);
                //Debug.Log(ShotRotation);

                //子弹数量--
                BulletNumber--;
                GameControl.SendMessage("BulletCount", BulletNumber);


				//打炮声音
				GunSound = gameObject.GetComponent<AudioSource>();
				GunSound.Play();

				//后座力
				transform.Find("tower").transform.Translate(new Vector3(0, -Back, 0));
				MoveHead += Back;

				//枪口火光
				GameObject flame = (GameObject)Instantiate(FireFlame);
				flame.transform.position = transform.Find("tower").transform.Find("Shoot").transform.position;
				flame.transform.rotation = transform.Find("tower").transform.Find("Shoot").transform.rotation;
				Destroy(flame, FlameLiveTime);
			}
           
        }

		if (MoveHead > 0)
		{
			transform.Find("tower").transform.Translate(new Vector3(0, 0.1f, 0));
			MoveHead -= 0.1f;
		}

	}

    public void GainBullet(int cnt)
    {
        BulletNumber = cnt;
        BulletNumberMax = cnt;
    }

    void AbilityUp()
    {
        ATN += 10.0f;
        Damage += 3.0f;
        Sunder += 0.02f;
    }
}
