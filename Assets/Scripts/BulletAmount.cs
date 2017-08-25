using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletAmount : MonoBehaviour {
    public GameObject HeroTank;
    public Text BulletNo;
    int BulletNumber;
    int BulletNumberMax;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        BulletNumber = HeroTank.GetComponent<Tank_Hero>().BulletNumber;
        BulletNumberMax = HeroTank.GetComponent<Tank_Hero>().BulletNumberMax;
        BulletNo.text = "子弹数量： " + BulletNumber + " / " + BulletNumberMax;
	}
}
