using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject ball;
	public Camera playerCamera;
	public Camera botCamera;
	public float movementSpeed;
	public LineRenderer lineRenderer;
	public int shotCount = 1;

	[HideInInspector] public float speed = 50f;

	private Rigidbody rb;
	private bool moving = true;
	private bool freeCam = false;
	private NInput NDSInput;
	private Vector3 direction;
	private Quaternion rotation;
	private int counter;
	private Touching touching;
	private Vector3 startPos;
	private bool setStartPos = false;
	private int resetFlag = 20;

	// Use this for initialization
	void Start () {
		rb = ball.GetComponent<Rigidbody>();
		NDSInput = new NInput();
		touching = (Touching) ball.GetComponent(typeof(Touching));
		rb.constraints = RigidbodyConstraints.None;
	}
	
	// Update is called once per frame
	void Update () {
		if (NDSInput.buttonA() && !moving && !freeCam) {
			makeShot();
        }

		if (NDSInput.buttonY() && counter == 0) {
			toggleFreecam();
        }

		if (NDSInput.buttonB() && setStartPos) {
			resetShot();
        }

		if (!freeCam) {
			rotateCam();
			if (!moving) {
				if (NDSInput.buttonUp_R() || NDSInput.buttonUp_D()) {
					speed = Mathf.Clamp(speed+1, 5, 100);
				}
				else if (NDSInput.buttonDown_R() || NDSInput.buttonDown_D()) {
					speed = Mathf.Clamp(speed-1, 5, 100);
				}
			}	
        }
		else {
			moveCam();
			rotateFreecam();
		}
		
		if (rb.velocity.magnitude != 0 && resetFlag == 0) {
			rb.velocity = rb.velocity * 0.995f;
			if (rb.velocity.magnitude <= 0.75f && rb.velocity.y <= 0.01f && rb.velocity.y >= -0.01f) {
				rb.velocity = Vector3.zero;
				moving = false;
			}
		}
		else if (resetFlag == 0) {
			moving = false;
		}
		if (!moving) {
			ball.transform.rotation = Quaternion.identity;
			if (!setStartPos) {
				startPos = ball.transform.position;
				setStartPos = true;
			}
			if (touching.isInvalid()) {
				ball.transform.position = startPos;
				playerCamera.transform.position = direction + ball.transform.position;
			}

		}
		if (counter > 0) {
			counter--;
		}
		if (resetFlag > 0) {
			resetFlag--;
		}
	}

	void LateUpdate() {
        drawLine();
    }

	void makeShot() {
		startPos = ball.transform.position;
		direction = playerCamera.transform.position - ball.transform.position;
		rb.constraints = RigidbodyConstraints.None;
		rb.velocity = Vector3.Normalize(Vector3.Scale(ball.transform.position - playerCamera.transform.position, new Vector3(1, 0, 1))) * speed * 0.75f;
		shotCount++;
		moving = true;
	}

	void toggleFreecam() {
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

	void resetShot() {
		rb.velocity = Vector3.zero;
		ball.transform.position = startPos;
		playerCamera.transform.position = direction + ball.transform.position;
		moving = false;
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
		if (NDSInput.buttonL()) {
			playerCamera.transform.position += Vector3.Scale(playerCamera.transform.up, new Vector3(0, 1, 0)) * Time.deltaTime * movementSpeed;
		}
		if (NDSInput.buttonR()) {
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
		if (NDSInput.buttonRight() || NDSInput.buttonRight_D()) {
			playerCamera.transform.RotateAround(ball.transform.position, Vector3.up, movementSpeed * Time.deltaTime * rotateSpeed);
		}
		if (NDSInput.buttonLeft() || NDSInput.buttonLeft_D()) {
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
				playerCamera.transform.RotateAround(playerCamera.transform.position, -playerCamera.transform.right, movementSpeed * Time.deltaTime * 10f);	
			}
		}
		if (NDSInput.buttonDown_R()) {
			if (playerCamera.transform.eulerAngles.x <= 90f && playerCamera.transform.eulerAngles.x >= 0f) {
				playerCamera.transform.RotateAround(playerCamera.transform.position, playerCamera.transform.right, movementSpeed * Time.deltaTime * 10f);	
			}
		}
		if (NDSInput.buttonRight_R()) {
			playerCamera.transform.RotateAround(playerCamera.transform.position, Vector3.up, movementSpeed * Time.deltaTime * 10f);
		}
		if (NDSInput.buttonLeft_R()) {
			playerCamera.transform.RotateAround(playerCamera.transform.position, -Vector3.up, movementSpeed * Time.deltaTime * 10f);
		}
	}
	void drawLine() {
		if (moving || freeCam) {
			lineRenderer.positionCount = 0;
			return;
		}
		else {
			lineRenderer.positionCount = 2;
		}
		Vector3 radius = new Vector3(0, -ball.GetComponent<SphereCollider>().radius*0f, 0);
		lineRenderer.SetPosition(0, ball.transform.position + radius);
		Vector3 linePoint = Vector3.Normalize(Vector3.Scale(ball.transform.position - playerCamera.transform.position, new Vector3(1, 0, 1))) * speed * 0.05f + ball.transform.position;
        lineRenderer.SetPosition(1, linePoint);
	}

	public bool inGoal() {
		return touching.isGoal() && !moving;
	}

	public void reset(Vector3 newPos, Vector3 cameraPos, Vector3 botPos) {
		ball.transform.position = newPos;
		ball.transform.rotation = Quaternion.identity;
		moving = true;
		playerCamera.transform.position = cameraPos;
		botCamera.transform.position = botPos;
		playerCamera.transform.LookAt(ball.transform);
		direction = playerCamera.transform.position - ball.transform.position;
		shotCount = 0;
		freeCam = false;
		setStartPos = false;
		resetFlag = 20;
	}
}
