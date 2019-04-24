using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;
	public bool hit = false;

	private Animator anim;  

			
	private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(-5.5f, 0.5f, 0);

		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();

		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


		/*
		if (Input.GetKey (KeyCode.Space)) {
			transform.Translate(new Vector3(0, 4, 0) * Time.deltaTime);
		}

	*/	
		//new code

		if (hit == false) 
		{
			transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
			//Look for input to trigger a "flap".
			if (Input.GetKey (KeyCode.Space)) 
			{
				//...tell the animator about it and then...
				anim.SetBool("fly", true);
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				//  new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, 4 * speed));
			
			
				if(transform.position.x > 9.0f)
				{
					transform.position = new Vector3(-9.0f, transform.position.y, 0);
				}


			}
			/*

			if (Input.GetKeyUp (KeyCode.Space)) {
				//...tell the animator about it and then...
				anim.SetBool("fly", false);
			}

*/
		}
		if (transform.position.y < -2.3f) {

			transform.position = new Vector3 (transform.position.x, -2.3f, 0);

		}

	}
	private void OnTriggerEnter2D(Collider2D  other){
		if (other.gameObject.name.Equals("Wall") || other.gameObject.name.Equals("Wall (Clone)") 
			|| other.gameObject.name.Equals("Ground") || other.gameObject.name.Equals("Ground (Clone)"))
		{
			rb2d.velocity = Vector2.zero;
			hit = true;
			anim.SetBool ("fly", false);
			GameControl.instance.BirdDied ();
		}
	}
}
