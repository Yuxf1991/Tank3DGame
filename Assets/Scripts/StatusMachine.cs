using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusMachine : MonoBehaviour
{
    private bool Detected;
    private bool ToAttack;
    private bool BeAttacked;
    public GameObject AiTank;
    private Vector3 HeroPosition;
    // Use this for initialization
    void Start()
    {
    }

    void SetPosition(Vector3 hp) {
        HeroPosition = hp;
    }

    void SetDetected(bool b)
    {
        Detected = b;
    }

    void SetBeAttacked(bool b)
    {
        BeAttacked = b;
    }

    void SetToAttack(bool b)
    {
       ToAttack = b;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("HeroTank")) {
            return;
        }

        if (ToAttack) {
            AiTank.SendMessage("Stop");
            AiTank.SendMessage("SetTarget", GameObject.Find("HeroTank"));
            AiTank.SendMessage("Rotation");
            return;
        }
        if (Detected) {
            AiTank.SendMessage("MoveTo", HeroPosition);
            return;
        }
        if (BeAttacked) {
            AiTank.SendMessage("MoveTo", HeroPosition);
            return;
        }

        //没接收到任何信息则巡逻
        //AiTank.SendMessage("Patrol");
    }
}
