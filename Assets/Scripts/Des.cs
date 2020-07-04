using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour {
    public GameObject TankExplosion;
    public float m_ExplodeTime = 2.0f;
    public GameObject GameCtrl;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy() {
        if (!GameCtrl) {
            return;
        }

        GameCtrl.SendMessage("GunMinus");

    }

    public void Die()
    {
        GameObject TankExplode = (GameObject)Instantiate(TankExplosion);
        TankExplode.transform.position = transform.Find("Sandbags_3").transform.position;
        Destroy(gameObject);
        Destroy(TankExplode, m_ExplodeTime);
    }
}
