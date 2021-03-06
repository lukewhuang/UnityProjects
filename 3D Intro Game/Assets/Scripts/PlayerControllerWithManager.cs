using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWithManager: MonoBehaviour {

	//how fast the player will move in the x & z axis
	public float walkSpeed;

	//how much force our player has for a jump
	public float jumpSpeed;

	//sound source variables
	public AudioSource coinSound;

	public AudioSource enemySound;

	public AudioSource goalSound;

	//Variable to hold the rigidbody physics for the player
	Rigidbody playerRB;

	//variable to control each press of the spacebar
	bool canJump;

	//variable to control a jump when the player is touching the ground & platforms
	bool isGrounded;

	//camera distance from the player
	public float cameraDistZ = 6.0f;


	// Use this for initialization
	void Start () {
		walkSpeed = 5f;
		jumpSpeed = 5f;
		playerRB = GetComponent<Rigidbody> ();
		canJump = true;
		isGrounded = true;

		CameraFollowPlayer ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		WalkHandler ();
		JumpHandler ();

		CameraFollowPlayer ();
	}

	//walking scripts
	void WalkHandler(){
		//input on x horizontal axis
		float hAxis = Input.GetAxis("Horizontal");

		//input on z vertical axis
		float vAxis = Input.GetAxis("Vertical");

		//movement in x
		float moveX = transform.position.x + hAxis * walkSpeed * Time.deltaTime;

		//movement in z
		float moveZ = transform.position.z + vAxis * walkSpeed * Time.deltaTime;

		//movement vector3 no jump
		Vector3 movement = new Vector3(moveX, transform.position.y, moveZ);

		playerRB.MovePosition (movement);	
	}//walk handler

	//jump scripts
	void JumpHandler(){
		//input on y-jump axis
		float yAxis = Input.GetAxis("Jump");

		//movement in y
		float moveY =  yAxis * jumpSpeed;

		//jumping vector
		Vector3 jumpVector = new Vector3(0, moveY, 0);

		//check to see if the spacebar is pressed
		if (yAxis > 0) {

			//check to see if the spacebar is pressed and player is touching the ground or platform
			if (canJump && isGrounded) {
				playerRB.AddForce (jumpVector, ForceMode.VelocityChange);
				canJump = false;
				isGrounded = false;
			}
		} else {
			canJump = true;
		}


	}//end jumphandler


	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Coin")){
			//add one to the score
			GameManager.instance.IncreaseScore (1);

			//play coin collection sound
			coinSound.Play ();

			//remove coin from the game
			Destroy(other.gameObject);

		} 
		if (other.CompareTag("Enemy")){
			enemySound.Play ();
			GameManager.instance.DecreaseLives ();
		}

		if (other.gameObject.name.Equals("Goal")){
			goalSound.Play ();
			GameManager.instance.IncreaseLevel ();
		}

		if (other.gameObject.name.Equals ("Goal2")) {
			GameManager.instance.GameOver ();
		}

		if (other.CompareTag("Fallout") || other.gameObject.name.Equals("Void")){
			GameManager.instance.GameOver ();
		}
	
	}


	void OnCollisionEnter(Collision collision)
	{
		isGrounded = true;
	}


	void CameraFollowPlayer(){
		//get the camera
		Vector3 cameraPos = Camera.main.transform.position;

		//change the z value of the camera
		cameraPos.z = transform.position.z - cameraDistZ;

		//move the camera
		Camera.main.transform.position = cameraPos;
	}
}//end class
