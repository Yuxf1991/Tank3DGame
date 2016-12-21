using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public float MoveSpeed = 1.0f;
	public float AngleSpeed = 30.0f;
	public float MaxSpeed = 10.0f;
	public float FSpeed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float temp1=MoveSpeed, temp2=MaxSpeed;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
			temp1 *= FSpeed;
			temp2 *= FSpeed;
		} else {
		}

		Vector3 direction = Input.GetAxis("Vertical") * transform.forward;
		transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * AngleSpeed);
		if (Mathf.Sqrt(GetComponent<Rigidbody>().velocity.sqrMagnitude) < temp2)
		{
			Debug.Log("done");
			GetComponent<Rigidbody>().AddForce(direction.normalized * temp1, ForceMode.Acceleration);
		}

		Debug.Log(GetComponent<Rigidbody>().velocity);

	}
}
