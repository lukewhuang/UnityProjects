using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public float rotationSpeed = 50f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float rotationAngle = rotationSpeed * Time.deltaTime;
		transform.Rotate (Vector3.up * rotationAngle , Space.World);
	}
}
