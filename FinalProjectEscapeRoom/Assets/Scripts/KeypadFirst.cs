using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadFirst : MonoBehaviour {

	public GameObject keypad, door;
	public GameObject one, two, three, four, five, six, seven, eight, nine, zero, clear;

	public bool first, second, third, fourth;

	// Use this for initialization
	void Start () {
		keypad.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			keypad.SetActive (false);
		}
	

		if (first && second && third && fourth) {
			keypad.SetActive (false);
			door.SetActive (false);
		}

	}

	public void OnMouseDown()
	{
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if (hit.gameObject.name == "two") {
					first = true;
				} else if (hit.gameObject.name == "four") {
					second = true;
				} else if (hit.gameObject.name == "five") {
					third = true;
				} else if (hit.gameObject.name == "seven") {
					fourth = true;
				} else if (hit.gameObject.name == "clear") {
					first = false;
					second = false;
					third = false;
					fourth = false;
				}
			}

	}
}
