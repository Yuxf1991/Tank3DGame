using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isWin : MonoBehaviour {
    public GameObject GameCtrl;
    public string title;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "HeroTankBody")
        {
            GameCtrl.SendMessage(title);
        }
    }
}
