using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour {

	public GameObject[] letterBlocks;

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < 26; i++) {
			letterBlocks [i].transform.localScale = new Vector3 (5, 5, 5);
			letterBlocks[i].transform.position = new Vector3 (120, 10, 140 - 10 * i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
