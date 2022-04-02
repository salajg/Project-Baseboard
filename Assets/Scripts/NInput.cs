using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnityEngine.N3DS.Keyboard.SetType(N3dsKeyboardType.Qwerty);
	}
	public bool buttonA() {
		return (Input.GetKey("z") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.A));
	}
	public bool buttonB() {
		return (Input.GetKey("x") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.B));
	}
	public bool buttonX() {
		return (Input.GetKey("enter") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.X));
	}
	public bool buttonY() {
		return (Input.GetKey("space") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Y));
	}
	public bool buttonUp() {
		return (Input.GetKey("w") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Up));
	}
	public bool buttonDown() {
		return (Input.GetKey("s") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Down));
	}
	public bool buttonRight() {
		return (Input.GetKey("d") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Right));
	}
	public bool buttonLeft() {
		return (Input.GetKey("a") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_Left));
	}
	public bool buttonL() {
		return (Input.GetKey("n") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.L));
	}
	public bool buttonR() {
		return (Input.GetKey("m") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.R));
	}
	public bool buttonZL() {
		return (Input.GetKey("j") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.ZL));
	}
	public bool buttonZR() {
		return (Input.GetKey("k") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.ZR));
	}
	public bool buttonUp_R() {
		return (Input.GetKey("up") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Up));
	}
	public bool buttonDown_R() {
		return (Input.GetKey("down") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Down));
	}
	public bool buttonRight_R() {
		return (Input.GetKey("right") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Right));
	}
	public bool buttonLeft_R() {
		return (Input.GetKey("left") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Emulation_R_Left));
	}
	public bool buttonUp_D() {
		return (Input.GetKey("8") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Up));
	}
	public bool buttonDown_D() {
		return (Input.GetKey("2") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Down));
	}
	public bool buttonRight_D() {
		return (Input.GetKey("4") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Right));
	}
	public bool buttonLeft_D() {
		return (Input.GetKey("6") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Left));
	}
	public bool buttonStart() {
		return (Input.GetKey("=") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Start));
	}
	// public bool buttonSelect() {
	// 	return (Input.GetKey("-") || UnityEngine.N3DS.GamePad.GetButtonHold(N3dsButton.Select));
	// }
}
