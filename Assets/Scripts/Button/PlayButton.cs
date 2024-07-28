using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite playOnSprite;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        spriteRenderer.sprite = playOnSprite;
        SceneManager.LoadScene(1);
    }
}
