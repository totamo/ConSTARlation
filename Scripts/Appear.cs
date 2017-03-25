using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Appear : MonoBehaviour {

	public GameObject[] alignment = new GameObject[23];

	public int next;

	void Start() {	
		next = -1;
		for (int i = 0; i < 22; i++) {
			alignment [i].active = false;
		}
	}

	void Update() {
		if (next == 12 || next == 18) {
			alignment [next].active = true;
			next += 1;
			alignment [next].active = true;
		}
		else if (next > -1) {
			alignment [next].active = true;				
		}
		if (next >= 21) {
			SceneManager.LoadScene ("WinScreen");
		}
	}
}
