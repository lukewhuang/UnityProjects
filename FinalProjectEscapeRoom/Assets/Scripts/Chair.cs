using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chair : MonoBehaviour {

	public Text chairText;
	public GameObject firstHint;
	public GameObject chair;
	public bool check; 

	// Use this for initialization
	void Awake () {
		chairText.enabled = false;
		firstHint.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		chairText.enabled = true;
	}

	void OnTriggerExit(Collider other)
	{
		chairText.enabled = false;
	}

	void OnMouseDown()
	{
		if (!check) {
			chair.transform.Translate (1, 0, 1);
			chair.transform.Rotate (0, 30, 0);
			firstHint.SetActive (true);
			check = true;
		}
	}

}
