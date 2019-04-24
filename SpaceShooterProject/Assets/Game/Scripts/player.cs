using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject laserPrefab;

    public float fireRate = 0.5f;
    public float canFire = 0.0f;

    public bool canTripleShot = false;
    public GameObject tripleLaserPrefab;

    public int life = 3;

    public GameObject shipExplosionPrefab;

    public bool shieldOn = false;

    public GameObject shieldGameObject;

	public UIManager uiManagerScript;
	public GameManager gameManagerScript;

	public AudioSource laserSound;
	public AudioSource explosionSound;
	public AudioSource powerUpSound;

	public GameObject[] engines;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Name: " + name);
        Debug.Log("X pos: " + transform.position.x);
        Debug.Log(transform.position);

        transform.position = new Vector3(0, 0, 0);
        

		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();

		if(uiManagerScript!=null){
			uiManagerScript.UpdateLives(life);
		}

		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();


		AudioSource[] audios = GetComponents<AudioSource>();
		laserSound = audios[0];
		explosionSound = audios[1];
		powerUpSound = audios[2];



    }

    // Update is called once per frame
    void Update()
    {
        //move player
        float horizontalInput = Input.GetAxis("Horizontal");
 
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * horizontalInput);

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed * verticalInput);

        //keep player on the screen
        if(transform.position.x > 9.4f)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }
        else if (transform.position.y > 5.6f)
        {
            transform.position = new Vector3(transform.position.x, -5.6f, 0);
        }
        else if (transform.position.y < -5.6f)
        {
            transform.position = new Vector3(transform.position.x, 5.6f, 0);
        }

        //spawn laser and Control fire rate
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //cooldown
            if(Time.time > canFire){

				laserSound.Play();

				//powerup - triple shot
                if( canTripleShot){
                    Instantiate(tripleLaserPrefab, transform.position + new Vector3
                    (.05f,-.06f,0), Quaternion.identity);
                }//end canTripleshot check
                else{
                     Instantiate(laserPrefab, transform.position + new Vector3
                    (0,.146f,0), Quaternion.identity);
                }

                canFire = Time.time + fireRate;

            }//end canFire check
            
        }//end space bar and mouse button check

        if(life <= 0){
            Instantiate(shipExplosionPrefab, transform.position, Quaternion.identity);
            
			gameManagerScript.gameOver=true;
			uiManagerScript.ShowTitle();
			Destroy(gameObject);
        }

        if(shieldOn){
            shieldGameObject.SetActive(true);
        }else{
            shieldGameObject.SetActive(false);
        }
        
		uiManagerScript.UpdateLives(life);

    }//end update method

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Equals("PowerUpTripleShot(Clone)")){
            
			powerUpSound.Play();

			canTripleShot = true;
            Destroy(other.gameObject);
            StartCoroutine(TripleShotPowerDown());
        }
        if(other.name.Equals("PowerUpSpeedBoost(Clone)")){
           
			powerUpSound.Play();

			speed = speed * 2;
            Destroy(other.gameObject);
            StartCoroutine(SpeedBoostPowerDown());
        }

        if(other.name.Equals("PowerUpShield(Clone)")){
           
			powerUpSound.Play();

			shieldOn = true;
            Destroy(other.gameObject);
            StartCoroutine(ShieldPowerDown());
        }
        
        if(other.name.Contains("Enemy")){
			explosionSound.Play();

			other.GetComponent<Enemy>().resetEnemy();
            if (shieldOn==false)
            {
               life = life - 1; 
				engines [0].SetActive (false);
				if (life == 2) {
					engines [1].SetActive (true);
					engines [2].SetActive (true);
				}
				if (life == 1) {
					engines [1].SetActive (false);
				
				}
            }
			else if(shieldOn==true){
				uiManagerScript.UpdateScore();
			}
        }
    }

    public IEnumerator TripleShotPowerDown(){
        yield return new WaitForSeconds(5);
        canTripleShot = false;
    }

    public IEnumerator SpeedBoostPowerDown(){
        yield return new WaitForSeconds(5);
        speed = 5.0f;
    }

    public IEnumerator ShieldPowerDown(){
        yield return new WaitForSeconds(5);
        shieldOn = false;
    }


    public void SetLife(int value){
        life = life - value;
    }

}
