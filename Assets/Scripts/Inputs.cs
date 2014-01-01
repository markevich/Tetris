using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour {
  bool active;
	void Start () {
    active = false;
	}
	
	void Update () {
    var axis = Input.GetAxisRaw ("Horizontal");
    switch ((int)axis) {
    case  0:
        active = false;
        break;
    case -1:
      if(!active){
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard> ().MoveLeft ();
        active = true;
      }
      break;
    case 1:
      if(!active){
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard> ().MoveRight ();
        active = true;
      }
      break;
    }
  }
}
