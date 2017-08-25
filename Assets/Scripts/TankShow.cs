using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShow : MonoBehaviour {
    public GameObject EveTank;
    public GameObject EvePre;
    int EveCnt = 0;
    Vector3 Offset = new Vector3(10, 0, -15);
	void Start () {
		
	}

    public void Create() {
        Vector3 TempPosition = EvePre.transform.position + EveCnt * Offset;
        GameObject Eve = (GameObject)Instantiate(EveTank, TempPosition, EvePre.transform.rotation);
        Debug.Log(Eve.transform.position);
        Debug.Log(EvePre.transform.position);
        EveCnt++;
    }

    void Update () {
		
	}
}
