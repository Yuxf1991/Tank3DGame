using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStatus : MonoBehaviour {
    private bool ToAttack;
    public GameObject AiGun;
    private Vector3 HeroPosition;

    GameObject GameCtrl;
    void Start () {
        GameCtrl = GameObject.Find("GameStatus");
        GameCtrl.SendMessage("GunPlus");
	}
    void SetToAttack(bool b)
    {
        ToAttack = b;
    }
    void SetPosition(Vector3 hp)
    {
        HeroPosition = hp;
    }

    public void toAttack() {


    }
    void OnDestroy() {

    }

    void Update () {
        if (ToAttack)
        {
            AiGun.SendMessage("SetTarget", GameObject.Find("HeroTank"));
            AiGun.SendMessage("Rotation");
            return;
        }
    }
}
