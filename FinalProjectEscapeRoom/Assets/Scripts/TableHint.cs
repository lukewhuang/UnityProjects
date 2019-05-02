using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableHint : MonoBehaviour {

	public GameObject firstHint;


	// Use this for initialization
	void Awake () {
		firstHint.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		firstHint.SetActive(true);
	}


}
