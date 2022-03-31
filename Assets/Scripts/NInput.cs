using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnityEngine.N3DS.Keyboard.SetType(N3dsKeyboardType.Qwerty);
	}
	public bool buttonA() {
		return (Input.GetMouseButtonDown(0) || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.A));
	}
	public bool buttonB() {
		return (Input.GetMouseButtonDown(1) || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.B));
	}
	public bool buttonX() {
		return (Input.GetKeyDown("enter") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.X));
	}
	public bool buttonY() {
		return (Input.GetKeyDown("space") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Y));
	}
	public bool buttonUp() {
		return (Input.GetKeyDown("w") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Up));
	}
	public bool buttonDown() {
		return (Input.GetKeyDown("s") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Down));
	}
	public bool buttonRight() {
		return (Input.GetKeyDown("d") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Right));
	}
	public bool buttonLeft() {
		return (Input.GetKeyDown("a") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Left));
	}
	public bool buttonL() {
		return (Input.GetKeyDown("n") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.L));
	}
	public bool buttonR() {
		return (Input.GetKeyDown("m") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.R));
	}
	public bool buttonZL() {
		return (Input.GetKeyDown("j") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.ZL));
	}
	public bool buttonZR() {
		return (Input.GetKeyDown("k") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.ZR));
	}
	public bool buttonUp_R() {
		return (Input.GetKeyDown("up") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Up));
	}
	public bool buttonDown_R() {
		return (Input.GetKeyDown("down") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Down));
	}
	public bool buttonRight_R() {
		return (Input.GetKeyDown("right") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Right));
	}
	public bool buttonLeft_R() {
		return (Input.GetKeyDown("left") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Left));
	}
}
