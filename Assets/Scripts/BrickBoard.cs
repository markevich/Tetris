using UnityEngine;
using System.Collections;

public class BrickBoard : MonoBehaviour
{
  private GameObject[,] board;

	public void Fall ()
	{
    if(HasCollisions()){
      MergeWithMainBoard();
      Clear();
      SpawnNewBrick();
    }
    else{
      for (int i = 0; i < board.GetLength(0); i++) {
        for (int j = board.GetLength(1) - 1; j > 0; j--) {
          board[i, j].renderer.enabled = board[i, j - 1].renderer.enabled;
        }
      }

      for(int i = 0; i< board.GetLength(0); i++)
        board[i, 0].renderer.enabled = false;
    }
	}
	// Use this for initialization
	void Start ()
	{
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
    SpawnNewBrick();
	}

  void SpawnNewBrick(){
    var column = Random.Range(0, board.GetLength(0));
    for (int i=0; i < 4; i++)
      board [column, i].renderer.enabled = true;
  }

  bool HasCollisions(){
    return(FloorCollision() || MainBoardCollision());
  }

  bool FloorCollision(){
    for(int i = 0; i< board.GetLength(0); i++)
      if(board[i, board.GetLength(1) - 1].renderer.enabled)
        return true;
    return false;
  }

  bool MainBoardCollision(){
    var mainBoard = GameObject.Find("MainBoard").GetComponent<MainBoard>();
    for (int i = 0; i < board.GetLength(0); i++)
      for (int j = 0; j < board.GetLength(1) - 1; j++)
        if(board[i, j].renderer.enabled && mainBoard.EnabledAt(i, j + 1))
          return true;
    return false;
  }

  void Clear(){
    foreach (var brick in board) {
      brick.renderer.enabled = false;
    }
  }

  void MergeWithMainBoard(){
    var mainBoard = GameObject.Find("MainBoard").GetComponent<MainBoard>();
    for (int i = 0; i < board.GetLength(0); i++) {
      for (int j = 0; j< board.GetLength(1); j++) {
        if(board[i, j].renderer.enabled)
          mainBoard.EnableBrick(i, j);
      }
    }
  }
}
