using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour {
    private int TankAmount = 0;
    private int GunAmount = 0;
    public GameObject Title;
    private bool isPause = false;
    private int level = -1;
    public GameObject PauseCanvas;
    public GameObject Weapon1, Weapon2;
    public GameObject EveTankPre;
    public GameObject HeroTank;
    public GameObject Gate;
    public GameObject WinHH;
    public GameObject FailButton;
    public GameObject FailureMusic;
    public GameObject NextLel;
    public GameObject HPShow;
    AudioSource BGM;
    AudioSource Fail;
    int EveNumberofLevel3 = 0;

    void Start () {
        Cursor.visible = false;
        NextLel.SetActive(false);
        FailButton.SetActive(false);
    }
    public void GunPlus() {
        GunAmount++;
    }
    public void GunMinus()
    {
        GunAmount--;
        CheckClean();
    }
    public void TankPlus()
    {
        TankAmount++;
    }
    public void Aword()
    {
        HeroTank.SendMessage("StatusRecover", 1000);
        HeroTank.SendMessage("AbilityUp");
        HeroTank.SendMessage("DEFUp");
    }

    void CheckClean() {
        if (TankAmount == 0 && GunAmount == 0&&level==0)
        {
            Title.SendMessage("PlayTitles", "AllClear.txt");
        }
        if (TankAmount == 0 && GunAmount == 0 && level == 3)
        {
            if (EveNumberofLevel3 < 20)
            {
                EveTankPre.SendMessage("Create");
                EveTankPre.SendMessage("Create");
                EveTankPre.SendMessage("Create");
                EveNumberofLevel3 += 3;
            }
            else
            {
                Title.SendMessage("PlayTitles", "ClearAndGoToWin.txt");
            }
        }
    }

    public void SetLevel()
    {
        level++;
        //Debug.Log("misson " + level);
    }

    public void TankMinus()
    {

        TankAmount--;
        CheckClean();
    }

    public void AmmoEnter() {
        if (level == 1) {
            Title.SendMessage("PlayTitles", "GetAmmo.txt");
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Gate.SetActive(false);
            HeroTank.SendMessage("GainBullet", 300);
            Aword();
        }
    }

    public void GetOut() {
        if (level == 2) {
            Title.SendMessage("PlayTitles", "GetOut.txt");
            EveTankPre.SendMessage("Create");
            EveTankPre.SendMessage("Create");
            EveNumberofLevel3 += 2;
        }

    }
    public void Win()
    {
        if (level == 4)
        {
            Title.SendMessage("PlayTitles", "Win.txt");
            WinHH.SetActive(false);
            NextLel.SetActive(true);
            Cursor.visible = true;
            Aword();
        }
    }

    public void GameFailure()
    {
        BGM = gameObject.GetComponent<AudioSource>();
        Fail = FailureMusic.GetComponent<AudioSource>();
        BGM.Stop();
        Fail.Play();
        HPShow.GetComponent<HeroHPShow>().HP.text = "坦克状态： " + 0 + "%"; ;
        Cursor.visible = true;
        FailButton.SetActive(true);
    }

    public void BulletCount(int cnt)
    {
        if (cnt <= 0 && (TankAmount > 0 || GunAmount > 0))
        {
            //Debug.Log("Defeat!!!!");
            GameFailure();
        }
    }

    void Update () {


	}
}
