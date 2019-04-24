using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	/*bool check = true;
	float celsius = 23.5f;
	float fahrenheit = 50f;
*/
	public float scaleFactor = 1.2f;

	public float maxScale = 3;

	// Use this for initialization
	void Start () {
	/*	Debug.Log ("hello");
		check = false;
		fahrenheit = celsius * 9/5 + 32;
		Debug.Log (fahrenheit);
	*/
		if (scaleFactor < 1.0f) {
			Debug.Log ("The balloon is too small");
		}
	}
	
	// Update is called once per frame
	void Update () {
	/*	if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Ouch");
		}

	*/
	}

	void OnMouseDown(){

		float xScale = transform.localScale.x;
		float yScale = transform.localScale.y;
		float zScale = transform.localScale.z;

		transform.localScale = new Vector3 (xScale*1.2f, yScale*1.2f, zScale*1.2f);

		if (xScale < 4f)
			Destroy (gameObject);
	}
}
