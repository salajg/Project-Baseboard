using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuRunner : MonoBehaviour {

	public Button playButton;
	public Button quitButton;
	public GameObject loadingScreen;
	public GameObject menu;
	public Image loadingBar;
	public Image cursor;
	private NInput NDSInput;
	private bool menuFlag = false;
	private int[] cursorPos = {10, -40};
	// Use this for initialization
	void Start () {
		NDSInput = new NInput();
		NDSInput.emulation = Application.isPlaying;
		loadingScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		cursor.color = new Color(0.75f + 0.1f * Mathf.Sin(Time.time * 2), 0.75f + 0.1f * Mathf.Sin(Time.time * 2), 0.75f + 0.1f * Mathf.Sin(Time.time * 2), 1);
		if (NDSInput.buttonA() || NDSInput.buttonStart()) {
			if (cursor.transform.localPosition.y == cursorPos[0]) {
				play();
			}
			else if (cursor.transform.localPosition.y == cursorPos[1]) {
				exit();
			}
		}
		if (NDSInput.buttonDown() || NDSInput.buttonDown_D()) {
			cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, cursorPos[1], cursor.transform.localPosition.z);
		}
		if (NDSInput.buttonUp() || NDSInput.buttonUp_D()) {
			cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, cursorPos[0], cursor.transform.localPosition.z);
		}
	}

	public void play(){
		if (menuFlag) {
			return;
		}
		menuFlag = true;
		loadingScreen.SetActive(true);
		menu.SetActive(false);
		StartCoroutine(LoadYourAsyncScene());
	}
	public void exit(){
		Debug.Log("Exiting");
		Application.Quit();
	}

	IEnumerator LoadYourAsyncScene() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Course");
        while (!asyncLoad.isDone)
        {
			loadingBar.fillAmount = asyncLoad.progress;
            yield return null;
        }
    }
}
