using UnityEngine;
using System.Collections;

public class WallPool : MonoBehaviour 
{
	public int wallPoolSize = 5;
	public GameObject wallsPrefab;
	public float spawnRate = 4.0f;
	public float wallMin = -1.9f;
	public float wallMax = 1.75f;


	private GameObject[] walls;
	private Vector2 objectPoolPosition = new Vector2 (-15f, 20f);
	private float timeSinceLastSpawned;
	private float spawnXPosition = 10f;
	private int currentWall = 0;




	void Start(){
		walls = new GameObject[wallPoolSize];

		for (int i = 0; i < wallPoolSize; i++) {
			walls [i] = (GameObject)Instantiate (wallsPrefab, objectPoolPosition, Quaternion.identity);
		}
	}

	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;


	
		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0;
			float spawnYPosition = Random.Range (wallMin, wallMax);
			walls [currentWall].transform.position = new Vector2 (spawnXPosition, spawnYPosition);

			currentWall++;

			if (currentWall >= wallPoolSize) {
				currentWall = 0;
			}
		}
	}
}