using UnityEngine;
using System.Collections;

public class Turn : MonoBehaviour {
	const float turnTime = 0.2f;
	private float pastTime;
	void Start () {
		pastTime = 0;
	}
	
	void Update () {
		pastTime += Time.deltaTime;
		if(pastTime > turnTime){
			Tick();
			pastTime = 0;
		}
	}

	void Tick(){
		GameObject.Find("BrickBoard").GetComponent<BrickBoard>().MoveDown();
	}
}
