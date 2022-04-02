﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameRunner : MonoBehaviour {

	private Shoot shoot;
	private string[] lines;
	private int numHoles;
	private int currHole = 1;
	public int course;
	public int hole;
	public int par;
	// Use this for initialization
	void Start () {
		shoot = GetComponent<Shoot>();
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
		if(shoot.inGoal() || Input.GetKeyDown("r")) {
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
	}


	void Read(){
        lines = System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/levels.csv");
        numHoles = lines.Length - 1;
    }
}
