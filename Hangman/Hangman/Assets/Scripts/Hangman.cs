using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangman : MonoBehaviour {

	public GameObject Head, Arm1, Arm2, Leg1, Leg2, Body, noose;
	GameManager man;

	// Use this for initialization
	void Start () {

		man = GameObject.Find("GameManager").GetComponent<GameManager>();

		Head.SetActive (false);
		Arm1.SetActive (false);
		Arm2.SetActive (false);
		Body.SetActive (false);
		Leg1.SetActive (false);
		Leg2.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Destroyed(){
		if (!Head.activeSelf)
		{	Head.SetActive (true);
			noose.SetActive (true);
		}
		else if (!Arm1.activeSelf)
			Arm1.SetActive (true);
		else if (!Arm2.activeSelf)
			Arm2.SetActive (true);
		else if (!Body.activeSelf)
			Body.SetActive (true);
		else if (!Leg1.activeSelf)
			Leg1.SetActive (true);
		else if (!Leg2.activeSelf) {
			// GAME OVER
			man.GameOver();
		}
	}
}
