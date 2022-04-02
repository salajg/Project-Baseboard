using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userInterface : MonoBehaviour {

	public Image power;
    public Text score;
    public Text header;
    private Shoot shoot;
    private gameRunner game;
	// Use this for initialization
	void Start () {
        shoot = GetComponent<Shoot>();
        game = GetComponent<gameRunner>();
		power.fillAmount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		power.fillAmount = shoot.speed * 0.01f;
        power.color = calcColor(power.fillAmount);
        score.text = "Shot: " + (shoot.shotCount+1);
        header.text = "Course: 1" + " - Hole: " + game.hole + " - Par: " + game.par;
	}

    Color calcColor(float val) {
        return Color.HSVToRGB(val, 1, 1);
    }
}
