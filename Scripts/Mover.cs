﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public Vector2 speed;

	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent < Rigidbody2D> ();
		rb.velocity = speed;
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = speed;
	}
}
