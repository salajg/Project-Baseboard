using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
	public Camera playerCamera;
	public GameObject center;
	public GameObject windmill;
	public float movementSpeed;


	void Start()
	{
		playerCamera.transform.LookAt(center.transform);
	}

	void Update()
	{
		windmill.transform.Rotate(Vector3.up * Time.deltaTime * movementSpeed * 5f);
		playerCamera.transform.RotateAround(center.transform.position, -Vector3.up, movementSpeed * Time.deltaTime);
	}
}
