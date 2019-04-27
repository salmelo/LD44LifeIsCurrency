using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Extensions
{
    public static T Get<T, TKey>(this Dictionary<TKey, T> dict, TKey key)
    {
        if (dict.TryGetValue(key, out var val))
        {
            return val;
        }
        return default;
    }

    public static Vector2 ToFloat(this Vector2Int v)
    {
        return new Vector2(v.x, v.y);
    }

}

