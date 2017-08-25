using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public GameObject EveBullet;
    public GameObject FireFlame;
    public float FlameLiveTime = 0.2f;
    private GameObject AttackObject;
	AudioSource GunSound;
    public float Back;
    public float MoveHead;
    public float FireBreak;
    public float AngularSpeed;
    private float LastFire = -1;

	public float ATN = 80.0f;
	public float Damage = 8.0f;
	public float Sunder = 0.05f;

    void Start() {

    }
    void SetTarget(GameObject ao) {
        AttackObject = ao;
    }

    void Rotation() {
        Vector3 v1 = AttackObject.transform.position - transform.position;
        v1 = v1.normalized;
        Vector3 v2 = transform.forward;
        v2 = v2.normalized;
     //    Debug.Log(v1 + " " + v2+" "+(v1.x*v2.x+v1.z*v2.z)+" "+(v1.x*v2.z-v1.z*v2.x));
        float Turn = v1.x * v2.z - v1.z * v2.x;
        //做叉积，Turn大于0右转，小于0左转
        if (Turn > 0) 
           transform.Rotate(0, AngularSpeed, 0, Space.Self);
        else
            transform.Rotate(0, -AngularSpeed, 0, Space.Self);
        if (Mathf.Abs(Turn) < 0.01) {
            this.Fire(); 

        }
    }

    void Fire() {
        //发射子弹
        if (LastFire > 0 && Time.time - LastFire < FireBreak)
        {
            return;
        }
        LastFire = Time.time;
        GameObject go = (GameObject)Instantiate(EveBullet);
		transform.FindChild("tower").transform.Translate(new Vector3(0, -Back, 0));
        MoveHead += Back;
        go.transform.position = transform.FindChild("tower").transform.FindChild("Shoot").transform.position;
        go.transform.rotation = transform.FindChild("tower").transform.FindChild("Shoot").transform.rotation;

		Vector3 BP = new Vector3(ATN, Damage, Sunder);//用一个数组把子弹威力装起来
		go.SendMessage ("BulletPower", BP);
        go.transform.Rotate(0, 90, 0);

		//子弹的声音
		GunSound = gameObject.GetComponent<AudioSource>();
		GunSound.Play();

		//枪口火光
		GameObject flame = (GameObject)Instantiate(FireFlame);
		flame.transform.position = transform.FindChild("tower").transform.FindChild("Shoot").transform.position;
		flame.transform.rotation = transform.FindChild("tower").transform.FindChild("Shoot").transform.rotation;
		Destroy(flame, FlameLiveTime);
    }


	// Update is called once per frame
	void Update () {

        if (MoveHead > 0)
        {
            transform.FindChild("tower").transform.Translate(new Vector3(0, 0.1f, 0));
            MoveHead -= 0.1f;
        }
			
    }
}
