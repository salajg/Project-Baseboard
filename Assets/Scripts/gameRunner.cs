using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameRunner : MonoBehaviour {
	
	public int course;
	public int hole;
	public int par;
	public Image cursor;

	private Shoot shoot;
	private NInput NDSInput;
	private string[] lines;
	private int numHoles;
	private int currHole = 1;
	private int counter = 120;
	private bool nextFlag = false;
	private userInterface UI;
	private bool menuFlag = false;
	private bool pauseFlag = false;
	private int[] cursorPos = {20, -20, -60};
	private int menuOption = 0;
	private int menuCount = 0;
	
	// Use this for initialization
	void Start () {
		shoot = GetComponent<Shoot>();
		UI = GetComponent<userInterface>();
		NDSInput = new NInput();
		NDSInput.emulation = Application.isPlaying;
		Read();
		var data = lines[currHole].Split(',');
		course = int.Parse(data[0]);
		hole = int.Parse(data[1]);
		par = int.Parse(data[11]);
		Vector3 newPos = new Vector3(float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
		Vector3 cameraPos = new Vector3(float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]));
		Vector3 botPos = new Vector3(float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]));
		shoot.reset(newPos, cameraPos, botPos);
	}
	
	// Update is called once per frame
	void Update () {
		if((shoot.inGoal() || Input.GetKeyDown("h")) && !nextFlag) {
			nextFlag = true;
			UI.enableTopUI();
		}
		if (nextFlag) {
			if (counter < 0) {
				UI.disableTopUI();
				loadNextHole();
				counter = 120;
				nextFlag = false;
			}
			else {
				counter--;
			}
		}
		if (pauseFlag != shoot.paused) {
			

			if (shoot.paused) {
				UI.enablePauseMenu();
				menuOption = 0;
				menuCount = 0;
				cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, cursorPos[menuOption], cursor.transform.localPosition.z);
			}
			else {
				UI.disablePauseMenu();
			}	
			pauseFlag = shoot.paused;
		}
		if (shoot.paused) {
			cursor.color = new Color(0.75f + 0.1f * Mathf.Sin(Time.time * 2), 0.75f + 0.1f * Mathf.Sin(Time.time * 2), 0.75f + 0.1f * Mathf.Sin(Time.time * 2), 1);
			if ((NDSInput.toggleDown() || NDSInput.toggleDown_D()) && menuCount <= 0) {
				menuOption = (menuOption + 1) % 3;
				cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, cursorPos[menuOption], cursor.transform.localPosition.z);
				menuCount = 10;
			}
			if ((NDSInput.toggleUp() || NDSInput.toggleUp_D()) && menuCount <= 0) {
				if (menuOption == 0) {
					menuOption = 3;
				}
				menuOption = (menuOption - 1) % 3;
				cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, cursorPos[menuOption], cursor.transform.localPosition.z);
				menuCount = 10;
			}
			if (NDSInput.buttonA()) {
				if (menuOption == 0) {
					Continue();
				}
				else if (menuOption == 1) {
					Restart();
				}
				else if (menuOption == 2) {
					Menu();
				}
			}
			if (NDSInput.buttonX()) {
				Restart();
			}
			if (NDSInput.buttonY()) {
				Menu();
			}
		}
		if (menuCount > 0) {
			menuCount--;
		}
	}

	public void Continue() {
		shoot.togglePause(true);
	}

	public void Restart() {
		var data = lines[currHole].Split(',');
		course = int.Parse(data[0]);
		hole = int.Parse(data[1]);
		par = int.Parse(data[11]);
		Vector3 newPos = new Vector3(float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
		Vector3 cameraPos = new Vector3(float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]));
		Vector3 botPos = new Vector3(float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]));
		shoot.reset(newPos, cameraPos, botPos);
		shoot.togglePause(false);
	}

	public void Menu() {
		if (menuFlag) {
			return;
		}
		menuFlag = true;
		StartCoroutine(LoadYourAsyncScene());
	}

	void loadNextHole() {
		currHole += 1;
		if(currHole > numHoles) {
			currHole = 1;
		}
		var data = lines[currHole].Split(',');
		course = int.Parse(data[0]);
		hole = int.Parse(data[1]);
		par = int.Parse(data[11]);
		Vector3 newPos = new Vector3(float.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]));
		Vector3 cameraPos = new Vector3(float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]));
		Vector3 botPos = new Vector3(float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]));
		shoot.reset(newPos, cameraPos, botPos);
	}

	void Read(){
        lines = System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/levels.csv");
        numHoles = lines.Length - 1;
    }

	IEnumerator LoadYourAsyncScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
