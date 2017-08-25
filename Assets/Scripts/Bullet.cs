using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject Explosion;
	public float ExplodeTime = 0.1f;

    public float m_Speed;
	public float m_LiveTime = 2.0f;

	private float m_ATN; //子弹威力
	private float m_Damage; //子弹伤害系数
	private float m_Sunder; //子弹破甲能力
	private int RealDamage; //该子弹造成的真实伤害
	private float HeroDEF, EveDEF;//敌我双方护甲

    // Use this for initialization
    void Start()
    {
		//发射出子弹后，子弹根据初速度前进
		GetComponent<Rigidbody>().AddForce(-transform.right * m_Speed, ForceMode.Impulse);

		//如果没有碰撞，则在一定时间后销毁子弹
        Destroy(gameObject, m_LiveTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
		
	void OnCollisionEnter(Collision collision)//碰撞进入
	{
		//碰撞之后销毁子弹
		Destroy (gameObject);
		//得到碰撞位置
		ContactPoint contacts = collision.contacts[0];

		//根据敌我双方护甲，计算子弹造成的伤害，并传递到Status脚本计算扣血量
		if (this.tag == "HeroBullet") 
		{
			GameObject target = collision.collider.gameObject;
			if (target.tag == "EveTankBody")
			{
				EveDEF = target.GetComponentInParent<EveStatus> ().DEF;
				RealDamage = (int) (m_ATN / (EveDEF * (1.0f - m_Sunder)) * m_Damage);
				target.GetComponentInParent<EveStatus> ().SendMessage("DamageToEve", RealDamage);
			}
            if (target.tag == "EnemyGun") {
                target.transform.parent.SendMessage("Die");
            }
            if (target.tag == "Fuel")
            {
                target.SendMessage("Boom");
            }

        }
		else if (this.tag == "EveBullet")
		{
			//m_damage = (int) (EveATN / (HeroDEF * (1.0f - EveSunder)) * EveDamage);
			GameObject target = collision.collider.gameObject;
			if (target.tag == "HeroTankBody")
			{
				HeroDEF = target.GetComponentInParent<HeroStatus> ().DEF;
				RealDamage = (int) (m_ATN / (HeroDEF * (1.0f - m_Sunder)) * m_Damage);
				target.GetComponentInParent<HeroStatus> ().SendMessage("DamageToHero", RealDamage);
			}
            if (target.tag == "Fuel")
            {
                target.SendMessage("Boom");
            }
        }


        //爆炸火光
        GameObject Explode = (GameObject)Instantiate(Explosion);
		Explode.transform.position = contacts.point;
		Destroy(Explode, ExplodeTime);
		//Explode.transform.rotation = transform.rotation;
	}

	//得到子弹的初速度
	void SetSpeed(float SpeedLevel)
	{
		m_Speed = SpeedLevel;
	}

	//得到该子弹的威力
	void BulletPower(Vector3 BP)
	{
		m_ATN = BP.x;
		m_Damage = BP.y;
		m_Sunder = BP.z;
	}

}