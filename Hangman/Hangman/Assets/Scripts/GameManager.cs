using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {



	public static GameManager instance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver(){
		Debug.Log ("Game Over");
		SceneManager.LoadScene ("GameOver");
	}

	public void ResetGame(){
		SceneManager.LoadScene ("Game");
	
	}

	public void NextLevel(){
		Debug.Log ("Next Level");
		SceneManager.LoadScene ("level2");
	}
}
