using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiteButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite quiteOnSprite;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        spriteRenderer.sprite = quiteOnSprite;
        Application.Quit();
    }
}
