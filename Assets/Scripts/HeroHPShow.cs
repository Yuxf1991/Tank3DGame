using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHPShow : MonoBehaviour {
    public GameObject HeroTank;
    public Text HP;
    int HPNow;
    int HPMax;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!HeroTank) {
            return;
        }

        HPNow = HeroTank.GetComponent<HeroStatus>().m_HP;
        HPMax = HeroTank.GetComponent<HeroStatus>().MaxHP;
        int Tankstatus = (int)((float)HPNow / (float)HPMax * 100);
        HP.text = "坦克状态： " + Tankstatus + "%";
    }
}
