using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NInput : MonoBehaviour {

	public bool emulation = false;
	// Use this for initialization
	void Start () {
		UnityEngine.N3DS.Keyboard.SetType(N3dsKeyboardType.Qwerty);
	}
	public bool buttonA() {
		return (Input.GetButton("ButtonA") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.A));
	}
	public bool buttonB() {
		return (Input.GetButton("ButtonB") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.B));
	}
	public bool buttonX() {
		return (Input.GetButton("ButtonX")|| UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.X));
	}
	public bool buttonY() {
		return (Input.GetButton("ButtonY") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Y));
	}
	public bool buttonUp() {
		return (Input.GetAxis("Vertical") > 0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Up));
	}
	public bool buttonDown() {
		return (Input.GetAxis("Vertical") < -0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Down));
	}
	public bool buttonRight() {
		return (Input.GetAxis("Horizontal") > 0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Right));
	}
	public bool buttonLeft() {
		return (Input.GetAxis("Horizontal") < -0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Left));
	}
	public bool buttonL() {
		return (Input.GetAxis("Triggers") > 0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.L));
	}
	public bool buttonR() {
		return (Input.GetAxis("Triggers") < -0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.R));
	}
	public bool buttonZL() {
		return (Input.GetButton("ButtonZL") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.ZL));
	}
	public bool buttonZR() {
		return (Input.GetButton("ButtonZR") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.ZR));
	}
	public bool buttonUp_R() {
		return (Input.GetAxis("Vertical_R") > 0.1f  || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Up));
	}
	public bool buttonDown_R() {
		return (Input.GetAxis("Vertical_R") < -0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Down));
	}
	public bool buttonRight_R() {
		return (Input.GetAxis("Horizontal_R") > 0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Right));
	}
	public bool buttonLeft_R() {
		return (Input.GetAxis("Horizontal_R") < -0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Left));
	}
	public bool buttonUp_D() {
		return (Input.GetAxis("Vertical_D") > 0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Up));
	}
	public bool buttonDown_D() {
		return (Input.GetAxis("Vertical_D") < -0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Down));
	}
	public bool buttonRight_D() {
		return (Input.GetAxis("Horizontal_D") > 0.1f || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Right));
	}
	public bool buttonLeft_D() {
		return (Input.GetAxis("Horizontal_D") < -0.1f  || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Left));
	}
	public bool buttonStart() {
		return (Input.GetButton("Start") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Start));
	}
	// public bool buttonSelect() {
	// 	return (Input.GetKey(-) || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Select));
	// }
}
