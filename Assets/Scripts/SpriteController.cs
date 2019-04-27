using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class SpriteController : MonoBehaviour
{
    public SpriteSheet sheet;

    private SpriteRenderer ren;

    private void Start()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        ren.sprite = sheet?.GetSprite(sheet.GetKeyName(ren.sprite.name)) ?? ren.sprite;
    }
}
