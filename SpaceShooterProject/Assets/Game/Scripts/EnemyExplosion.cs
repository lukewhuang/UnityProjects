﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.down * Time.deltaTime);
		if(transform.position.y<-7f){
			Destroy(gameObject);
		}

	}
}