using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed;

	public float jumpSpeed;

	Vector3 movement;

	Rigidbody playerRB;
	public bool canJump;
	public bool isGrounded;

	public AudioSource coinSound;

	// Use this for initialization
	void Start () {
		coinSound = GetComponent<AudioSource> ();
		walkSpeed = 5f;
		jumpSpeed = 5f;
		playerRB = GetComponent<Rigidbody> ();
		canJump = true;
		isGrounded = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		WalkHandler ();
		JumpHandler ();

	}//end update

	public void WalkHandler()
	{
		float hAxis = Input.GetAxis ("Horizontal");

		float vAxis = Input.GetAxis ("Vertical");

		float moveX = transform.position.x + hAxis * walkSpeed * Time.deltaTime;

		float moveZ = transform.position.z + vAxis * walkSpeed * Time.deltaTime;

		movement = new Vector3 (moveX, transform.position.y, moveZ);

		transform.position = movement;
	}

	public void JumpHandler(){
		float yAxis = Input.GetAxis ("Jump");

		float moveY = yAxis * jumpSpeed;

		Vector3 jumpVector = new Vector3 (0, moveY, 0);

		if (yAxis > 0) {
			if (canJump && isGrounded){
				playerRB.AddForce (jumpVector, ForceMode.VelocityChange);
				canJump = false;
				isGrounded = false;
			} else {
				canJump = true;
			}
		}
	}

	void OnCollisionEnter(Collision collision){
		isGrounded = true;
	}

	void OnTriggerEnter( Collider other){
		
		Destroy(other.gameObject);
		coinSound.Play ();
	}
}
