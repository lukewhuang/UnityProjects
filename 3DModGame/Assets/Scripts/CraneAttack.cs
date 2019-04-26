using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneAttack : MonoBehaviour {

	private Animator anim;
	public bool left;
	public bool right;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		left = false;
		right = false;

	}

	// Update is called once per frame
	void Update () {
		if(left)
			anim.SetBool ("attackLeft", true);
		else
			anim.SetBool ("attackLeft", false);
		
		if(right)
			anim.SetBool ("attackRight", true);
		else
			anim.SetBool ("attackRight", false);
	}


}
