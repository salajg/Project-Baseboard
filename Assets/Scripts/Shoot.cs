using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject ball;
	public Camera playerCamera;
	public float speed;
	private Rigidbody rb;
	private bool moving = false;
	private bool freeCam = false;
	private NInput NDSInput;
	public float movementSpeed;
	private Vector3 direction;
	private Quaternion rotation;
	public LineRenderer lr;
	public int shotCount = 0;
	private int counter;
	private Touching touching;
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		rb = ball.GetComponent<Rigidbody>();
		NDSInput = new NInput();
		playerCamera.transform.position = ball.transform.position + (Vector3.back * 4) + (Vector3.up * 2);
		direction = playerCamera.transform.position - ball.transform.position;
		touching = (Touching) ball.GetComponent(typeof(Touching));
		startPos = ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (NDSInput.buttonA() && !moving && !freeCam) {
			startPos = ball.transform.position;
			direction = playerCamera.transform.position - ball.transform.position;
			rb.constraints = RigidbodyConstraints.None;
            rb.velocity = Vector3.Normalize(Vector3.Scale(ball.transform.position - playerCamera.transform.position, new Vector3(1, 0, 1))) * speed * 0.75f;
			shotCount++;
			moving = true;
        }

		if (NDSInput.buttonY() && counter == 0) {
			if (!freeCam) {
				direction = playerCamera.transform.position - ball.transform.position;
				rotation = playerCamera.transform.rotation;
			}
			else {
				playerCamera.transform.position = direction + ball.transform.position;
				playerCamera.transform.rotation = rotation;
			}
			freeCam = !freeCam;
			counter = 20;
        }

		if (NDSInput.buttonB()) {
			ball.transform.position = startPos;
			playerCamera.transform.position = direction + ball.transform.position;
			moving = false;
        }

		if (!freeCam) {
			rotateCam();
			if (!moving) {
				if (NDSInput.buttonUp_R()) {
					speed = Mathf.Clamp(speed+1, 15, 100);
				}
				else if (NDSInput.buttonDown_R()) {
					speed = Mathf.Clamp(speed-1, 15, 100);
				}
			}	
        }
		else {
			moveCam();
			rotateFreecam();
		}

		if (rb.velocity.magnitude != 0) {
			rb.velocity = rb.velocity * 0.995f;
			if (rb.velocity.magnitude <= 0.75f) {
				rb.velocity = Vector3.zero;
				moving = false;
			}
		}
		else {
			moving = false;
		}
		if (!moving) {
			rb.constraints = RigidbodyConstraints.FreezeAll;
			if (touching.isInvalid()) {
				ball.transform.position = startPos;
				playerCamera.transform.position = direction + ball.transform.position;
			}
		}
		if (counter > 0) {
			counter--;
		}
	}

	void LateUpdate() {
        drawLine();
    }

	void moveCam() {
		if (NDSInput.buttonUp()) {
			playerCamera.transform.position += Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)) * Time.deltaTime * movementSpeed;
		}
		if (NDSInput.buttonDown()) {
			playerCamera.transform.position -= Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)) * Time.deltaTime * movementSpeed;
		}
		if (NDSInput.buttonRight()) {
			playerCamera.transform.position += Vector3.Scale(playerCamera.transform.right, new Vector3(1, 0, 1)) * Time.deltaTime * movementSpeed;
		}
		if (NDSInput.buttonLeft()) {
			playerCamera.transform.position -= Vector3.Scale(playerCamera.transform.right, new Vector3(1, 0, 1)) * Time.deltaTime * movementSpeed;
		}
		if (NDSInput.buttonZL()) {
			playerCamera.transform.position += Vector3.Scale(playerCamera.transform.up, new Vector3(0, 1, 0)) * Time.deltaTime * movementSpeed;
		}
		if (NDSInput.buttonZR()) {
			Vector3 temp = playerCamera.transform.position - Vector3.Scale(playerCamera.transform.up, new Vector3(0, 1, 0)) * Time.deltaTime * movementSpeed;
			if(temp.y > 0.5f) {
				playerCamera.transform.position = temp;
			}
		}
	}
	void rotateCam() {
		playerCamera.transform.position = direction + ball.transform.position;
		if (NDSInput.buttonUp()) {
			if ((playerCamera.transform.eulerAngles.x <= 75f  || playerCamera.transform.eulerAngles.x >= 358f) && playerCamera.transform.eulerAngles.x >= 0f) {
				playerCamera.transform.RotateAround(ball.transform.position, playerCamera.transform.right, movementSpeed * Time.deltaTime * 5f);	
			}
		}
		if (NDSInput.buttonDown()) {
			if (playerCamera.transform.eulerAngles.x <= 90f && playerCamera.transform.eulerAngles.x >= 0f) {
				playerCamera.transform.RotateAround(ball.transform.position, -playerCamera.transform.right, movementSpeed * Time.deltaTime * 5f);	
			}
		}
		float rotateSpeed = 5f;
		if (NDSInput.buttonZR()) {
			rotateSpeed = 1f;
		}
		if (NDSInput.buttonRight()) {
			playerCamera.transform.RotateAround(ball.transform.position, Vector3.up, movementSpeed * Time.deltaTime * rotateSpeed);
		}
		if (NDSInput.buttonLeft()) {
			playerCamera.transform.RotateAround(ball.transform.position, -Vector3.up, movementSpeed * Time.deltaTime * rotateSpeed);
		}
		Vector3 tdir = playerCamera.transform.position - ball.transform.position;
		if (NDSInput.buttonR() && tdir.magnitude > 0.4f && tdir.magnitude < 25f) {
			playerCamera.transform.position = ball.transform.position + 1.01f * tdir;
		}
		if (NDSInput.buttonL() && tdir.magnitude > 0.5f && tdir.magnitude < 26f) {
			playerCamera.transform.position = ball.transform.position + 0.99f * tdir;
		}
		direction = playerCamera.transform.position - ball.transform.position;
	}
	void rotateFreecam() {
		if (NDSInput.buttonUp_R()) {
			if ((playerCamera.transform.eulerAngles.x <= 75f  || playerCamera.transform.eulerAngles.x >= 358f) && playerCamera.transform.eulerAngles.x >= 0f) {
				playerCamera.transform.RotateAround(playerCamera.transform.position, -playerCamera.transform.right, movementSpeed * Time.deltaTime * 5f);	
			}
		}
		if (NDSInput.buttonDown_R()) {
			if (playerCamera.transform.eulerAngles.x <= 90f && playerCamera.transform.eulerAngles.x >= 0f) {
				playerCamera.transform.RotateAround(playerCamera.transform.position, playerCamera.transform.right, movementSpeed * Time.deltaTime * 5f);	
			}
		}
		if (NDSInput.buttonRight_R()) {
			playerCamera.transform.RotateAround(playerCamera.transform.position, Vector3.up, movementSpeed * Time.deltaTime * 5f);
		}
		if (NDSInput.buttonLeft_R()) {
			playerCamera.transform.RotateAround(playerCamera.transform.position, -Vector3.up, movementSpeed * Time.deltaTime * 5f);
		}
	}
	void drawLine() {
		if (moving || freeCam) {
			lr.positionCount = 0;
			return;
		}
		else {
			lr.positionCount = 2;
		}
		Vector3 radius = new Vector3(0, -ball.GetComponent<SphereCollider>().radius*0f, 0);
		lr.SetPosition(0, ball.transform.position + radius);
		Vector3 linePoint = Vector3.Normalize(Vector3.Scale(ball.transform.position - playerCamera.transform.position, new Vector3(1, 0, 1))) * speed * 0.05f + ball.transform.position;
        lr.SetPosition(1, linePoint);
	}
}
