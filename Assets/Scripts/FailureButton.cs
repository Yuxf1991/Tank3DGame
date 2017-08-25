using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailureButton : MonoBehaviour {
    public Button Fail;



    // Use this for initialization
    void Start () {
        Fail.onClick.AddListener(TaskOnClick);
	}

    public void TaskOnClick()
    {
        Debug.Log("Defeat!!!!!");
        SceneManager.LoadScene("StartMenu");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
