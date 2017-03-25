using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public GameObject explosion;

	void Start(){
		Destroy (gameObject, 10f);
	}
	void OnCollisionEnter2D(Collision2D other) {
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

}
