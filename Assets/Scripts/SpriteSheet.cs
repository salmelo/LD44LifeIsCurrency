using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[CreateAssetMenu]
public class SpriteSheet : ScriptableObject
{
    [SerializeField]
    private List<Sprite> spriteList = null;

    private Dictionary<string, Sprite> sprites;

    [SerializeField]
    private string _keyPattern = ".+_(.+)";
    public string KeyPattern { get => _keyPattern; set => _keyPattern = value; }

    [SerializeField]
    private RegexOptions _regexOptions;
    public RegexOptions RegexOptions { get => _regexOptions; set => _regexOptions = value; }

    private void OnEnable()
    {
        if (spriteList == null) return;
        sprites = new Dictionary<string, Sprite>();
        var r = new Regex(KeyPattern, RegexOptions);
        foreach (var sprite in spriteList)
        {
            var match = r.Match(sprite.name);
            if (match.Success)
            {
                sprites.Add(match.Groups[1].Value, sprite);
            }
            else
            {
                sprites.Add(sprite.name, sprite);
            }
        }
    }

    public string GetKeyName(string fullname)
    {
        var m = Regex.Match(fullname, _keyPattern);
        if (m.Success)
        {
            return m.Groups[1].Value;
        }
        return fullname;
    }

    public Sprite GetSprite(string name)
    {
        if (sprites.TryGetValue(name, out var sprite))
        {
            return sprite;
        }
        return null;
    }
}
