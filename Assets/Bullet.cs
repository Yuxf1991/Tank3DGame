using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float m_Speed = 100;
	public float m_LiveTime = 1;
	public float m_Power = 1.0f;

	protected Transform m_trasform;

	// Use this for initialization
	void Start () {
		m_trasform = this.transform;  
		Destroy(this.gameObject, m_LiveTime); 
	}
	
	// Update is called once per frame
	void Update () {
		m_trasform.Translate(-m_Speed * Time.deltaTime, 0,  0);
	}
}