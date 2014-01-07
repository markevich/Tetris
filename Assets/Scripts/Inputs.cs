using UnityEngine;
using System.Collections;

public class Inputs : MonoBehaviour {
  bool horizontalActiveNow;
  bool verticalActiveNow;
	void Start () {
    horizontalActiveNow = false;
    verticalActiveNow = false;
	}
	
	void Update () {
    HorizontalInput();
    VerticalInput();
  }

  void HorizontalInput()
  {
    var axis = Input.GetAxisRaw ("Horizontal");
    switch ((int)axis) {
    case 0:
      horizontalActiveNow = false;
      break;
    case -1:
      if (!horizontalActiveNow) {
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard> ().MoveLeft ();
        horizontalActiveNow = true;
      }
      break;
    case 1:
      if (!horizontalActiveNow) {
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard> ().MoveRight ();
        horizontalActiveNow = true;
      }
      break;
    }
  }

  void VerticalInput(){
    var axis = Input.GetAxisRaw ("Vertical");
    switch ((int)axis) {
    case 0:
      verticalActiveNow = false;
      break;
    case 1:
      if(!verticalActiveNow){
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard>().Rotate();
        verticalActiveNow = true;
      }
      break;
    case -1:
      if(!verticalActiveNow){
        GameObject.Find ("BrickBoard").GetComponent<BrickBoard>().MoveDown();
        verticalActiveNow = true;
      }
      break;
    }
  }
}
