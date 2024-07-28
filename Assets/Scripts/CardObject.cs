using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private CardFront cardFront;
    [SerializeField] private Sprite testSprite;
    public static event EventHandler OnClick;

    private void OnMouseDown()
    {
        if(CardManager.Instance.CanClick() && !PauseGameManager.Instance.IsPauseGame() && EventManager.Instance.isAlive())
        {
            cardBack.SetActive(false);
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
    public void SetSpriteForCardFront(Sprite sprite)
    {
        cardFront.SetSpirte(sprite);
    }

    public void HideCard()
    {
        gameObject.SetActive(false);
    }
    public void ShowCardBack()
    {
        cardBack.SetActive(true);
    }
    public CardFront GetCardFront()
    {
        return cardFront;
    }
}
