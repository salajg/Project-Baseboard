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
		if(power.fillAmount < 0.2f)
        {
            power.color = Color.red;
        }
        else if(power.fillAmount < 0.6f)
        {
            power.color = Color.yellow;
        }
        else
        {
            power.color = Color.green;
        }
        score.text = "Shot: " + shoot.shotCount;
        header.text = "Course: " + game.course + " - Hole: " + game.hole + " - Par: " + game.par;
	}
}
