using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BoardObject
{
    public Board Board { get; }
    public Vector2Int Position => Board.GetPosition(this);

    public BoardObject(Board board)
    {
        Board = board;
    }
}

