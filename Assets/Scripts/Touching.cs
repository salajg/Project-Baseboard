using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching : MonoBehaviour {

	private bool invalid;
	// Use this for initialization
	void Start () {
		invalid = false;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == 8) {
			invalid = true;
		}
		if (collision.gameObject.layer == 9) {
			invalid = false;
		}
    }

	public bool isInvalid() {
		return invalid;
	}
}
