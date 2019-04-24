using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;
	public Text scoreText;
	public GameObject gameOvertext;
	public GameObject IntroTitleText;

	private int score = 0;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;

	public AudioSource scoreSound;


	//test
	public bool firstPointTesting = false;
	// test

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		Destroy (IntroTitleText, 3f);

		AudioSource[] audios = GetComponents<AudioSource> ();
		scoreSound = audios[0];

	}
	void Update()
	{
		if (gameOver && Input.GetKey (KeyCode.Space))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void BirdScored()
	{
		if (gameOver)
			return;

		score++;

		scoreText.text = "Score: " + score.ToString ();
		scoreSound.Play ();
		firstPointTesting = true;
	}

	public void BirdDied()
	{
		gameOvertext.SetActive (true);
		gameOver = true;
	}


}
