using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockRotation : MonoBehaviour {

	private Quaternion iniRot;
 
	void Start(){
		iniRot = transform.rotation;
	}
 
	void LateUpdate(){
		transform.rotation = iniRot;
		transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y+ 5, transform.parent.position.z);
	}
}
