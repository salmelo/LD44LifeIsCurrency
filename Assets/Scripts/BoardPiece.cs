using UnityEngine;
using System.Collections;

public class BoardPiece : MonoBehaviour
{

    public BoardObject BoardObject { get; private set; }

    // Use this for initialization
    void Start()
    {
        BoardObject = new BoardObject(BoardManager.Current.Board);

        BoardManager.Current.Board.Place(BoardObject, BoardManager.Current.tilemap.WorldToCell(transform.position).XY());
    }

    private void OnEnable()
    {
        BoardManager.Current.Board.ObjectPlaced += OnPlaced;
    }

    private void OnDisable()
    {
        BoardManager.Current.Board.ObjectPlaced -= OnPlaced;
    }

    void OnPlaced(BoardObject obj, Vector2Int pos)
    {
        if (obj == BoardObject)
        {
            transform.position = pos.ToFloat();
        }
    }
}
