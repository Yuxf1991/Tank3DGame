using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	float BulletRate = 0;
	public GameObject BulletPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		BulletRate -= Time.deltaTime;
		if ( BulletRate <= 0 )  
		{  
			BulletRate = 0.2f;  

			if ( Input.GetKey( KeyCode.Space ) || Input.GetMouseButton(0) )  
			{  
				GameObject go= (GameObject)Instantiate(BulletPrefab);
				go.transform.position = transform.position;
				go.transform.rotation = transform.rotation;
				go.transform.Rotate(0, 90, 0);
			}  
		}
		
	}
}
