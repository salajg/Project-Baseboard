using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public GameObject car;
	public float max;
	public float min;
	public float movementSpeed;
	public float rotationSpeed;

	private bool rotateflag;
	private float counter = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
		if (rotateflag) {
			rotate ();
		}
		else {
			car.transform.Translate(Vector3.down * Time.deltaTime * movementSpeed);
			if (counter <= 0) {
				if (car.transform.localPosition.z > max || car.transform.localPosition.z < min) {
					rotateflag = true;
					counter = 5;
				}
			}
			else {
				counter -= 1;
			}	
		}


	}

	void rotate(){
		car.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed * 5f);
		if (car.transform.localEulerAngles.y >= 179.5f && car.transform.localEulerAngles.y <= 180.5f) {
			rotateflag = false;
		}
		if (car.transform.localEulerAngles.y >= 359.5f || car.transform.localEulerAngles.y <= 0.5f) {
			rotateflag = false;
		}
	}
}
