using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageToCrane : MonoBehaviour {

	public CraneAttack crane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (crane.left);
	}

	void OnTriggerEnter(Collider other){
		if(gameObject.tag=="collideLeft")
			crane.left = true;
		if(gameObject.tag=="collideRight")
			crane.right = true;
	}

	void OnTriggerExit(Collider other){
		if(gameObject.tag=="collideLeft")
			crane.left = false;
		if(gameObject.tag=="collideRight")
			crane.right = false;
	}
}
