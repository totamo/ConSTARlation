using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 speed;
	public GameObject explosion;

	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent < Rigidbody2D> ();
		rb.velocity = speed;
		Destroy (gameObject, 10f);
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = speed;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (col.gameObject);
		}
	}
}
