using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerBar : MonoBehaviour {

	public Image power;
	// Use this for initialization
	void Start () {
		power.fillAmount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		Shoot shoot = GetComponent<Shoot>();
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
	}
}
