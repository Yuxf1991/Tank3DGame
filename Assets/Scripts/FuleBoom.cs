using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuleBoom : MonoBehaviour {
    public GameObject Explode;
    public GameObject Smoke;
    public GameObject Dust;
    public float m_ExplodeTime = 5.0f;
    public float SmokeTime = 10.0f;
    public float SaveTime = 10.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Boom()
    {
        GameObject FuelExplode = (GameObject)Instantiate(Explode);
        FuelExplode.transform.position = gameObject.transform.position;
        Destroy(FuelExplode, m_ExplodeTime);
        GameObject FuelSmoke = (GameObject)Instantiate(Smoke);
        FuelSmoke.transform.position = gameObject.transform.position;
        GameObject FuelDust = (GameObject)Instantiate(Dust);
        FuelDust.transform.position = gameObject.transform.position;
        Destroy(FuelSmoke, SmokeTime);
        Destroy(gameObject, SaveTime);

    }
}
