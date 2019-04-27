using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Board
{
    public Vector2Int Size { get; }

    private Dictionary<Vector2Int, BoardObject> objects = new Dictionary<Vector2Int, BoardObject>();
    
    public event UnityAction<BoardObject, Vector2Int> ObjectPlaced;

    public Board(int width, int height) : this(new Vector2Int(width, height)) { }

    public Board(Vector2Int size)
    {
        Size = size;
    }

    public BoardObject GetObjectAt(Vector2Int position)
    {
        return objects.Get(position);
    }
    public BoardObject GetObjectAt(int x, int y)
    {
        return GetObjectAt(new Vector2Int(x, y));
    }

    public Vector2Int GetPosition(BoardObject obj)
    {
        return (from pair in objects
                where pair.Value == obj
                select pair.Key).SingleOrDefault();
    }

    public void Place(BoardObject obj, int x, int y)
    {
        Place(obj, new Vector2Int(x, y));
    }
    public void Place(BoardObject obj, Vector2Int position)
    {
        if (objects.ContainsKey(position))
        {
            Debug.LogError($"Position {position} already contains object.");
            return;
        }
        if (objects.ContainsValue(obj))
        {
            objects.Remove(GetPosition(obj));
        }
        objects[position] = obj;

        ObjectPlaced?.Invoke(obj, position);
    }
}
