using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float speed = 5.0f;

	public bool hit = false;

	public GameObject enemyExplosionPrefab;
	public UIManager uiManagerScript;
	public AudioSource explosionSound;


	// Start is called before the first frame update
	void Start()
	{
		float randX = Random.Range(-7f,7f);
		float randY = Random.Range(7f,15f); 
		transform.position = new Vector3(randX, randY, 0);
	
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
		explosionSound = GetComponent<AudioSource> ();
			
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if(uiManagerScript.titleScreen.activeInHierarchy == true)
		{
			Destroy(gameObject);
		}

		if(transform.position.y < -7f || hit){
			StartCoroutine(MoveToRandom());
		}
	

	
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name.Equals("Laser(Clone)") || other.name.Equals("TripleLaser(Clone)")){
			hit = true;
			explosionSound.Play();
			uiManagerScript.UpdateScore();
		}
	}

	public void resetEnemy(){
		StartCoroutine(MoveToRandom());
	}

	public IEnumerator MoveToRandom(){

		Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
		float randX = Random.Range(-7f,7f);
		float randY = Random.Range(7f,15f);
		transform.position = new Vector3(randX, randY, 0);
		speed = 0;
		hit = false;    
		yield return new WaitForSeconds(2);
		speed = 5.0f;
	}


}