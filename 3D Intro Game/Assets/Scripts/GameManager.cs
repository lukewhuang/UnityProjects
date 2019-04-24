using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//score of player
	public int score = 0;

	//lives for player
	public int lives = 3;

	//high score for the game
	public int highScore = 0;

	//current level
	public int currentLevel = 1;

	//number of levels
	public int highestLevel = 2;

	HUDManager hud; 

	//instance of the GM that can be accessed from anywhere
	public static GameManager instance;

	void Awake(){
		//check to see if instance has been assigned
		if (instance == null) {
			//assign it to the current object
			instance = this;
		}
		//make sure that is equal to the current object
		else if (instance != this) {

			instance.hud = FindObjectOfType<HUDManager> ();

			//we do not need one so destroy it
			Destroy(gameObject);
		}

		//dont destroy this object when changing scenes
		DontDestroyOnLoad(gameObject);

		hud = FindObjectOfType<HUDManager> ();

	}

	//increase player score
	public void IncreaseScore(int amount){
		score += amount;

		Debug.Log("new score: " + score);

		//is there a new high score
		if (score > highScore) {
			highScore = score;
			Debug.Log("new record: " + highScore);
		}

		//update score text
		hud.ResetHud ();
	}

	//decrease lives by 1
	public void DecreaseLives(){
		lives--;

		//update lives text
		hud.ResetHud ();

		Debug.Log("num lives: " + lives);
		if (lives == 0) {
			GameOver ();
		}

	}

	//game reset
	public void ResetGame(){
		
		//reset the score
		score = 0;

		//reset number of lives
		lives = 3;

		//current level to 1
		currentLevel = 1;

		//update score and lives text
		hud.ResetHud ();

		//load first level
		SceneManager.LoadScene("level1");


	}

	//send player to next level
	public void IncreaseLevel(){

		//check for next level
		if (currentLevel < highestLevel) {
			
			//increase level by 1
			currentLevel++;
		} else {
			currentLevel = 1;
		}

		//load next level
		SceneManager.LoadScene("level"+currentLevel);
	}


	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Coin")) {

			GameManager.instance.IncreaseScore (1);
		}
			
		if (other.CompareTag ("Enemy")) {
			Debug.Log ("Hit Enemy");
		}

		if (other.CompareTag ("Goal")) {
			Debug.Log ("Level Complete");
		}

		Destroy (other.gameObject);
	}

	public void GameOver(){
		SceneManager.LoadScene ("GameOver");

	}
}
