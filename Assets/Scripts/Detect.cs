using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public GameObject StatusMachine;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
		if (other.tag == "HeroTankBody")
        {
            StatusMachine.SendMessage("SetDetected", true);
            StatusMachine.SendMessage("SetPosition", other.transform.position);
        }
    }
    void OnTriggerExit(Collider other) {
		if (other.tag == "HeroTankBody")
            StatusMachine.SendMessage("SetDetected", false);
    }

}