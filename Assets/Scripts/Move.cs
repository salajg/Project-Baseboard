using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float movementSpeed;

	// Use this for initialization
	void Start () {
		UnityEngine.N3DS.Keyboard.SetType(N3dsKeyboardType.Qwerty);
	}
	
	// Update is called once per frame
	void Update () {
		if (UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Up)) {
			transform.position += transform.forward * Time.deltaTime * movementSpeed;
		}
		if (UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Down)) {
			transform.position -= transform.forward * Time.deltaTime * movementSpeed;
		}
		if (UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Right)) {
			transform.position += transform.right * Time.deltaTime * movementSpeed;
		}
		if (UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Left)) {
			transform.position -= transform.right * Time.deltaTime * movementSpeed;
		}
	}
}
