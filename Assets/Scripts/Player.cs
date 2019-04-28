using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private BoardPiece piece;
    public BoardObject Obj => piece.BoardObject;

    private void Start()
    {
        piece = GetComponent<BoardPiece>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            TryMove(Obj.Position + Vector2Int.up);
        }
        else if (Input.GetButtonDown("Left"))
        {
            TryMove(Obj.Position + Vector2Int.left);
        }
        else if (Input.GetButtonDown("Right"))
        {
            TryMove(Obj.Position + Vector2Int.right);
        }
        else if (Input.GetButtonDown("Down"))
        {
            TryMove(Obj.Position + Vector2Int.down);
        }
    }

    public void TryMove(Vector2Int position)
    {
        if (CanEnter(position))
        {
            Obj.Board.Place(Obj, position);
        }
    }

    public bool CanEnter(Vector2Int position)
    {
        return BoardManager.Current.Board.GetTile(position) == BoardTile.Open;
    }

}
