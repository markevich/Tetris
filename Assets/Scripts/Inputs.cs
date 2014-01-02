using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour {
  bool activeNow;
	void Start () {
    activeNow = false;
	}
	
	void Update () {
    var axis = Input.GetAxisRaw ("Horizontal");
    switch ((int)axis) {
    case  0:
        activeNow = false;
        break;
    case -1:
      if(!activeNow){
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard> ().MoveLeft ();
        activeNow = true;
      }
      break;
    case 1:
      if(!activeNow){
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard> ().MoveRight ();
        activeNow = true;
      }
      break;
    }
  }
}
