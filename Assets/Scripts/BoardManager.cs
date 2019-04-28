using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour
{

    public static BoardManager Current { get; private set; }

    public Board Board { get; private set; }

    public Vector2Int size = new Vector2Int(10, 10);
    public UnityEngine.Tilemaps.Tilemap tilemap;
    public BoardTileMapping tileMapping;

    private void Awake()
    {
        Current = this;
        tilemap.CompressBounds();
        Board = new Board(tilemap.cellBounds);

        foreach (var pos in Board.Bounds.allPositionsWithin)
        {
            var tile = tilemap.GetTile(pos);
            if (tile && tileMapping.TryGetValue(tile, out var boardTile))
            {
                Board.SetTile(boardTile, pos.XY());
                //Debug.Log($"{pos.XY()}: {boardTile}");
            }
        }
    }

    // Use this for initialization
    void Start()
    {
    }
}
