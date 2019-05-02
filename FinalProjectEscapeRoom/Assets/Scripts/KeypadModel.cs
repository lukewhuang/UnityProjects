using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadModel : MonoBehaviour {

	public Text keyText;
	public GameObject model;

	// Use this for initialization
	void Awake () {
		keyText.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		keyText.enabled = true;
	}

	void OnTriggerExit(Collider other)
	{
		 keyText.enabled = false;
	}

	void OnMouseDown()
	{
		model.SetActive (true);
	}

}
