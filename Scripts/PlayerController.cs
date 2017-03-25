using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject playerExplosion;
	public GameObject explosion;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public AudioSource fireWeapon;
	public AudioSource starCollect;
	private int starsCollected;
	Appear appearScript;
	private bool dead;
	public Text scoreText;

	private float nextFire;

	void Start(){
		dead = false;
		scoreText.text = "Alignments Left: 22";
		GameObject alignment = GameObject.Find ("Alignment");
		appearScript = alignment.GetComponent<Appear> ();
	}

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, Quaternion.identity);
			fireWeapon.Play ();
		}

		if ((Input.GetAxisRaw ("Vertical") > 0.5f) || Input.GetAxisRaw ("Vertical") < -0.5f) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime, 0f));
		}

		if ((Input.GetAxisRaw ("Horizontal") > 0.5f) ||Input.GetAxisRaw ("Horizontal") < -0.5f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f ));			
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Enemy") {
			dead = true;
			Instantiate (playerExplosion, transform.position, transform.rotation);
			Destroy (gameObject);
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			SceneManager.LoadScene ("LoseScreen");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Star") {
			starCollect.Play ();
			col.enabled = false;
			appearScript.next += 1;
			if (appearScript.next > -1) {
				scoreText.text = "Alignments Left: " + (21 - appearScript.next);
			}
		}
	}


}

