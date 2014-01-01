﻿using UnityEngine;
using System.Collections;

public class MainBoard : MonoBehaviour {
	private GameObject[,] board;

	public void enableBrick(int i, int j){
		board[i, j].renderer.enabled = true;
	}

  public void disableAllBricks(){
    foreach (var brick in board) {
      brick.renderer.enabled = false;
    }
  }

	// Use this for initialization
	void Start () {
		board = new GameObject[10, 20];
		GameObject.Find("Brick").renderer.enabled = false;
		for (int i = 0; i < board.GetLength(0); i++)
			for (int j = 0; j < board.GetLength(1); j++) {
				var clone = (GameObject)Instantiate(GameObject.Find("Brick"));
				clone.transform.parent = this.transform;
				clone.name = string.Format("Brick_{0}_{1}", i, j);
				clone.transform.localPosition = new Vector2(Brick.Width * i, -Brick.Width * j);
				board[i, j] = clone;
			}
	}
	
 
	// Update is called once per frame
	void Update () {
	
	}
}
