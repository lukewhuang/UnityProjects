using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float walkSpeed;

	public float jumpSpeed;

	public float horizontalSpeed = 2F;
	public float verticalSpeed = 2F;

	Vector3 movement;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	// Use this for initialization
	void Start () {
		walkSpeed = 10f;
		jumpSpeed = 2f;

	}

	// Update is called once per frame
	void FixedUpdate () {

		float h = 2f * Input.GetAxis ("Mouse X");
		transform.Rotate (0, h, 0);

		yaw += horizontalSpeed * Input.GetAxisRaw ("Mouse X");
		pitch -= verticalSpeed * Input.GetAxisRaw ("Mouse Y");

		transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);



		//WalkHandler ();


	}//end update

	//public void WalkHandler()
	//{

		//float hAxis = Input.GetAxis ("Horizontal");

	//	float vAxis = Input.GetAxis ("Vertical");

	//	Vector3 movement = new Vector3 (hAxis, 0.0f, vAxis);

	//	transform.Translate (movement * walkSpeed * Time.deltaTime, Space.Self);


//	}




}

