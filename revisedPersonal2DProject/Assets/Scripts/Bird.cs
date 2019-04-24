using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;

	public bool begin = false;

	public AudioSource flapSound;
	public AudioSource hurtSound;
	public AudioSource scoreSound;


	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		AudioSource[] audios = GetComponents<AudioSource> ();
		flapSound = audios [0];
		hurtSound = audios [1];

	}

	void Update(){
		if (begin == false) {

			rb2d.bodyType = RigidbodyType2D.Static;

			if (Input.GetKeyDown (KeyCode.Space)) {
				begin = true;
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flap");

			}

		}

		if (begin == true) {
			if (isDead == false) {

				rb2d.bodyType = RigidbodyType2D.Dynamic;
				rb2d.angularVelocity = 0.05f;
				rb2d.gravityScale = 1f;

				if (Input.GetKeyDown (KeyCode.Space)) {
					rb2d.velocity = Vector2.zero;
					rb2d.AddForce (new Vector2 (0, upForce));
					anim.SetTrigger ("Flap");
					flapSound.Play ();
				}
			}

		}
	}
	void OnCollisionEnter2D(){
		isDead = true;
		hurtSound.Play ();
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}

}