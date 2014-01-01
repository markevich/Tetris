using UnityEngine;
using System.Collections;

public class BrickBoard : MonoBehaviour
{
	private bool needReupdate;
	private int[,] board;

	public void Fall ()
	{
		needReupdate = true;
	}
	// Use this for initialization
	void Start ()
	{
		board = new int[10, 20];
		for (int i=0; i < 4; i++)
				board [5, i] = 1;
		needReupdate = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (!needReupdate)
			return;

		for (int i = 0; i < board.GetLength(0); i++)
			for (int j = 0; j < board.GetLength(1); j++) {
				if (board [i, j] > 0) {
					GameObject.Find("MainBoard").GetComponent<MainBoard>().enableBrick(i, j);
				}
			}

		needReupdate = false;
	}
}
