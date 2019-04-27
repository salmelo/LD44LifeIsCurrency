using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour
{

    public static BoardManager Current { get; private set; }

    public Board Board { get; private set; }

    public Vector2Int size = new Vector2Int(10, 10);

    private void Awake()
    {
        Current = this;
        Board = new Board(size);
    }

    // Use this for initialization
    void Start()
    {
    }

}
