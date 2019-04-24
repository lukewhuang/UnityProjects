﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropoffBox : MonoBehaviour {

	LetterGuess guess;
	Hangman hm;
	public GameObject Head, Arm1, Arm2, Leg1, Leg2, Body, noose;

	GameObject guesser;
	public GameObject correct;
	AudioSource correctSound;
	public GameObject wrong;
	public int count = 0;

	public GameObject complete;
	AudioSource completeSound;

	AudioSource wrongSound;

	// Use this for initialization
	void Start () {

		wrong = GameObject.Find ("Dead Sound");
		wrongSound = wrong.GetComponent<AudioSource> ();

		correct = GameObject.Find ("Correct Sound");
		correctSound = correct.GetComponent<AudioSource> ();

		complete = GameObject.Find ("Complete Sound");
		completeSound = complete.GetComponent<AudioSource> ();

		hm = GameObject.Find ("Hangman").GetComponent<Hangman> ();
		guess = GameObject.Find ("Guessing").GetComponent<LetterGuess> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Letters")) {
			Destroy (other.gameObject);

			char[] array = LetterGuess.array;

			int correct = 0;


			for (int i = 0; i < array.Length; i++) {
				if (array[i].ToString () == other.name) {
					//Debug.Log (array [i]);
					guess.CubesVisible (i);
					correct++;
					count++;
					Debug.Log (count);
				} 

			}

			if (correct == 0) {
				wrongSound.Play ();
				hm.Destroyed ();
			} else {
				correctSound.Play ();
			}
			if (count == array.Length) {

				completeSound.Play ();

				StartCoroutine (Waiter ());
				SceneManager.LoadScene ("level2");
			}
		}
	}

	IEnumerator Waiter() {
		yield return new WaitForSeconds (3);
	}

}
