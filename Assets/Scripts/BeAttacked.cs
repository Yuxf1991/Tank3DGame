using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttacked : MonoBehaviour
{
    public GameObject StatusMachine;
    public GameObject Hero;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "HeroBullet")
        {
            StatusMachine.SendMessage("SetBeAttacked", true);
            StatusMachine.SendMessage("SetPosition", Hero.transform.position);
        }
    }

    void OnTriggerExit(Collider other)
    {
		if (other.tag == "HeroTankBody")
            StatusMachine.SendMessage("SetBeAttacked", false);
    }

}