using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public int score;


	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.GetComponent<Bird>() != null)
		{
			GameControl.instance.BirdScored ();
		}
	}

}
