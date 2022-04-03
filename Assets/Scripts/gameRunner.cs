using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameRunner : MonoBehaviour {
	
	public int course;
	public int hole;
	public int par;

	private Shoot shoot;
	private NInput NDSInput;
	private string[] lines;
	private int numHoles;
	private int currHole = 1;
	private int counter = 120;
	private bool nextFlag = false;
	private userInterface UI;
	private bool menuFlag = false;
	
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
		if (shoot.paused) {
			UI.enablePauseMenu();
			if (NDSInput.buttonX()) {
				Restart();
			}
			if (NDSInput.buttonY()) {
				Menu();
			}
		}
		else {
			UI.disablePauseMenu();
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
