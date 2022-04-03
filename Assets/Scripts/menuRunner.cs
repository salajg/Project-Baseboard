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
	private NInput NDSInput;
	private bool menuFlag = false;
	// Use this for initialization
	void Start () {
		NDSInput = new NInput();
		NDSInput.emulation = Application.isPlaying;
		loadingScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (NDSInput.buttonA()) {
			play();
		}
		if (NDSInput.buttonB()) {
			exit();
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
		#if UNITY_EDITOR
        	UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	IEnumerator LoadYourAsyncScene() {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Course");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
			loadingBar.fillAmount = asyncLoad.progress;
            yield return null;
        }
    }
}
