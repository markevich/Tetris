﻿using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour {
	const float turnTime = 2f;
	private float pastTime;
	// Use this for initialization
	void Start () {
		pastTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		pastTime += Time.deltaTime;
		if(pastTime > turnTime){
			Tick();
			pastTime = 0;
		}
	}

	void Tick(){
		GameObject.FindGameObjectWithTag("CurrentBrickBoard").GetComponent<BrickBoard>().Fall();
	}
}