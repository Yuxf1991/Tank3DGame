using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAttack : MonoBehaviour
{
    public GameObject StatusMachine;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {

		if (other.tag == "HeroTankBody")
        {
            StatusMachine.SendMessage("SetToAttack", true);
            StatusMachine.SendMessage("SetPosition", other.transform.position);
        }
    }
    void OnTriggerExit(Collider other)
    {
		if (other.tag == "HeroTankBody")
            StatusMachine.SendMessage("SetToAttack", false);
    }

}