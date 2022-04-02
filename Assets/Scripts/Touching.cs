using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touching : MonoBehaviour {

	private bool invalid;
	private bool goal;
	// Use this for initialization
	void Start () {
		invalid = false;
		goal = false;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == 8) {
			invalid = true;
		}
		if (collision.gameObject.layer == 9) {
			invalid = false;
		}
		if (collision.gameObject.layer == 11) {
			goal = true;
		}
		else {
			goal = false;
		}
    }

	public bool isInvalid() {
		return invalid;
	}

	public bool isGoal() {
		return goal;
	}
}
