using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public BoardPiece Player;

    private void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            BoardManager.Current.Board.Place(Player.BoardObject, Player.BoardObject.Position + Vector2Int.up);
        }
        else if (Input.GetButtonDown("Left"))
        {
            BoardManager.Current.Board.Place(Player.BoardObject, Player.BoardObject.Position + Vector2Int.left);
        }
        else if (Input.GetButtonDown("Right"))
        {
            BoardManager.Current.Board.Place(Player.BoardObject, Player.BoardObject.Position + Vector2Int.right);
        }
        else if (Input.GetButtonDown("Down"))
        {
            BoardManager.Current.Board.Place(Player.BoardObject, Player.BoardObject.Position + Vector2Int.down);
        }
    }

}
