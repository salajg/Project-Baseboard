using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userInterface : MonoBehaviour {

    public GameObject bottomUI;
	public Image power;
    public Text score;
    public Text header;

    public GameObject topUI;
    public Text topHeader;
    public Text shotsTaken;
    public Text message;

    public GameObject pauseUI;

    private Shoot shoot;
    private gameRunner game;
    private string[] messages; 
	// Use this for initialization
	void Start () {
        shoot = GetComponent<Shoot>();
        messages = new string[] {"Hole In One!", "Eagle!", "Birdie!", "Par!", "Bogey!", "Double Bogey!", "Triple Bogey!", "Quadruple Bogey!", "Quintuple Bogey!", "Sextuple Bogey!", "Septuple Bogey!", "Octuple Bogey!", "Nonuple Bogey!", "Decuple Bogey!", "Over Par!"};
        game = GetComponent<gameRunner>();
		power.fillAmount = 0.5f;
        bottomUI.SetActive(true);
        topUI.SetActive(false);
        pauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (bottomUI.activeSelf) {
            power.fillAmount = shoot.speed * 0.01f;
            power.color = calcColor(power.fillAmount);
            score.text = "Shot: " + (shoot.shotCount+1);
            header.text = "Course: 1" + " - Hole: " + game.hole + " - Par: " + game.par;
        }
	}

    public void enableTopUI() {
        bottomUI.SetActive(false);
        topUI.SetActive(true);
        topHeader.text = "Course: 1" + " - Hole: " + game.hole + " - Par: " + game.par;
        shotsTaken.text = "Shots Taken: " + shoot.shotCount;
        if (shoot.shotCount == 1) {
            message.text = messages[0];
        }
        else {
            int diff = shoot.shotCount - game.par;
            if (diff < -2) {
                message.text = (game.par - shoot.shotCount) + " under Par!";
            }
            else if (diff > 10) {
                message.text = (diff - 10) + " over Par!";
            }
            else {
                message.text = messages[diff + 3];
            }
        }
    }

    public void disableTopUI() {
        bottomUI.SetActive(true);
        topUI.SetActive(false);
    }

    public void enablePauseMenu() {
        if (bottomUI.activeSelf) {
            bottomUI.SetActive(false);
        }
        if (topUI.activeSelf) {
            topUI.SetActive(false);
        }
        pauseUI.SetActive(true);
    }

    public void disablePauseMenu() {
        bottomUI.SetActive(true);
        pauseUI.SetActive(false);
    }

    Color calcColor(float val) {
        return Color.HSVToRGB(val, 1, 1);
    }
}
