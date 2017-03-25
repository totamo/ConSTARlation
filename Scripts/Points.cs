using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {
	Appear appearScript;
		
	// Use this for initialization
	void Start () {
		GameObject alignment = GameObject.Find ("Alignment");
		appearScript = alignment.GetComponent<Appear> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
