using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEnter : MonoBehaviour {
    public GameObject GameCtrl;
    public string title;
	void Start () {
		
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "HeroTankBody") {
            GameCtrl.SendMessage(title);
        }
    }

}
