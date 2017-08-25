using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveStatus : MonoBehaviour {
	public GameObject TankExplosion;
	public float m_ExplodeTime = 2.0f;
    GameObject GameCtrl;
    public float DEF = 80.0f; //防御力
	private int m_HP = 100; //生命值

	// Use this for initialization
	void Start () 
	{
        GameCtrl = GameObject.Find("GameStatus");
        GameCtrl.SendMessage("TankPlus");
    }
	
	// Update is called once per frame
	void Update () 
	{
	}

	void DamageToEve(int RealDamage)
	{
		m_HP -= RealDamage;
		if (this.m_HP <= 0)
		{
			GameObject TankExplode = (GameObject)Instantiate(TankExplosion);
			TankExplode.transform.position = transform.position;
			Destroy(gameObject);
			Destroy(TankExplode, m_ExplodeTime);
		}
	}
    void OnDestroy() {
        GameCtrl.SendMessage("TankMinus");
    }
}
