using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStatus : MonoBehaviour {
	public GameObject TankExplosion;
    public GameObject GameCtrl;
	public float m_ExplodeTime;

	public float DEF = 100.0f; //防御力
	public int m_HP; //生命值
    public int MaxHP; //最大生命值

    // Use this for initialization
    void Start()
    {
        m_HP = 100;
        MaxHP = 100;
    }
	
	// Update is called once per frame
	void Update () {
	}

	void DamageToHero(int RealDamage)
	{
		m_HP -= RealDamage;
		if (this.m_HP <= 0)
		{
			GameObject TankExplode = (GameObject)Instantiate(TankExplosion);
			TankExplode.transform.position = this.transform.position;
			Destroy(gameObject);
			Destroy(TankExplode, m_ExplodeTime);
            GameCtrl.SendMessage("GameFailure");
		}
	}

    void StatusRecover(int temp)
    {
        m_HP = temp;
        MaxHP = temp;
    }

    void DEFUp()
    {
        DEF += 10.0f;
    }
}
