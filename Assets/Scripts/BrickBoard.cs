using UnityEngine;
using System.Collections;

public class BrickBoard : MonoBehaviour {
	const float Width = 40/100f;

	public void Fall(){
		transform.position = new Vector2(transform.position.x, transform.position.y - Width);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
