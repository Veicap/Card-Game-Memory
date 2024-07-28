using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFront : MonoBehaviour
{
    private SpriteRenderer spriteCardFont;
    private void Awake()
    {
        spriteCardFont = GetComponent<SpriteRenderer>();
    }
    public void SetSpirte(Sprite sprite)
    {
        spriteCardFont.sprite = sprite;
    }
    public Sprite GetSpirte()
    {
        return spriteCardFont.sprite;
    }
}
