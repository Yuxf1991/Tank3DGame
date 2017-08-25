using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTank : MonoBehaviour {
    public int CreateAmout;
    public float CreateBreak;
    public GameObject EveTank;

    public GameObject Hero;
	void Start () {
		
	}

    public IEnumerator Create() {
        for (int i = 0; i<CreateAmout; i++){
            GameObject go = (GameObject)Instantiate(EveTank);
            go.transform.position = transform.position;

            yield return new WaitForSeconds(CreateBreak);
            Debug.Log("create "+i);
        }

    }
	
    
	void Update () {
		
	}
}
