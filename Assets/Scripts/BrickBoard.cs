using UnityEngine;
using System.Collections;

public class BrickBoard : MonoBehaviour
{
  private GameObject[,] board;

  public void MoveDown()
  {
    if (HasBottomCollisions ()) {
      MergeWithMainBoard ();
      Clear ();
      SpawnNewBrick ();
    }
    else {
      for (int i = 0; i < board.GetLength (0); i++)
        for (int j = board.GetLength (1) - 1; j > 0; j--)
          board [i, j].renderer.enabled = board [i, j - 1].renderer.enabled;

      for (int i = 0; i < board.GetLength (0); i++)
        board [i, 0].renderer.enabled = false;
    }
  }

  public void MoveLeft(){
    if(HasLeftCollisions())
      return;
    for (int i = 0; i < board.GetLength(0) -1 ; i++)
      for (int j = 0; j < board.GetLength(1); j++)
        board[i, j].renderer.enabled = board[i + 1, j].renderer.enabled;

    for (int j = 0; j < board.GetLength(1); j++)
      board [board.GetLength(0) -1, j].renderer.enabled = false;
  }
  public void MoveRight(){
    if(HasRightCollisions())
      return;

    for (int i = board.GetLength(0) - 1; i > 0; i--)
      for (int j = 0; j < board.GetLength(1); j++)
        board[i, j].renderer.enabled = board[i - 1, j].renderer.enabled;
    
    for (int j = 0; j < board.GetLength(1); j++)
      board [0, j].renderer.enabled = false;
  }

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
    var randFigure = Random.Range(0, 2);
    if(randFigure == 0)
      for (int j=0; j < 4; j++)
        board [column, j].renderer.enabled = true;
    else{
      column = Mathf.Clamp(column, 1, board.GetLength(0) - 2);
      board[column, 0].renderer.enabled = true;
      board[column - 1, 1].renderer.enabled = true;
      board[column, 1].renderer.enabled = true;
      board[column + 1, 1].renderer.enabled = true;
    }
  }

  bool HasBottomCollisions(){
    return(FloorCollision() || MainBoardBottomCollision());
  }

  bool HasLeftCollisions(){
    return(LeftBoardCollision() || MainBoardLeftCollision());
  }

  bool HasRightCollisions(){
    return(RightBoardCollision() || MainBoardRightCollision());
  }

  bool RightBoardCollision(){
    for(int j = 0; j< board.GetLength(1); j++)
      if(board[board.GetLength(0) - 1, j].renderer.enabled)
        return true;

    return false;
  }

  bool MainBoardRightCollision(){
    var mainBoard = GameObject.Find("MainBoard").GetComponent<MainBoard>();
    for (int i = 0; i < board.GetLength(0) - 1; i++)
      for (int j = 0; j < board.GetLength(1); j++)
        if(board[i, j].renderer.enabled && mainBoard.EnabledAt(i + 1, j))
          return true;
    
    return false;
  }

  bool LeftBoardCollision ()
  {
    for (int j = 0; j < board.GetLength(1); j++)
      if(board[0, j].renderer.enabled)
        return true;

    return false;
  }

  bool MainBoardLeftCollision ()
  {
    var mainBoard = GameObject.Find("MainBoard").GetComponent<MainBoard>();
    for (int i = 1; i < board.GetLength(0); i++)
      for (int j = 0; j < board.GetLength(1); j++)
        if(board[i, j].renderer.enabled && mainBoard.EnabledAt(i - 1, j))
           return true;
    
    return false;
  }

  bool FloorCollision(){
    for(int i = 0; i< board.GetLength(0); i++)
      if(board[i, board.GetLength(1) - 1].renderer.enabled)
        return true;
    return false;
  }

  bool MainBoardBottomCollision(){
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
    mainBoard.ClearFilledLines();
  }
}
