using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour {
    public GameObject focus;
    // Use this for initialization
    public float height;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v3= focus.transform.position;
        v3.y = height;
        transform.position = v3;
	}
}
