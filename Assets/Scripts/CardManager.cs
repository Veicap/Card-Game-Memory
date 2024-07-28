using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    [SerializeField] CardObject cardObject;
    [SerializeField]private int row = 2;
    [SerializeField] private int col = 4;
    private readonly float offsetX = 3f;
    private readonly float offsetY = 2.5f;
    private float checkCardTimer = 0.5f;
    private int numberOfCard;
    private int numberOfMath;
    private int[] index;
    [SerializeField] private Sprite[] arrayOfSprite;
    private CardObject cardOpenedFirst;
    private CardObject cardOpenedSecond;
    public event EventHandler OnRemoveLife;
    public event EventHandler OnWin;
    public event EventHandler OnMatch;
    public event EventHandler OnNotMatch;
    private void Awake()
    {
        Instance = this;
        numberOfCard = row * col;
        numberOfMath = 0;
        index = new int[numberOfCard];
        int count = 0;
        for(int i = 0; i < numberOfCard/2; i++)
        {
            for(int j = 0; j < 2; j++)
            {

                index[count] = i;
                count++;
            }
        }
    }
    private void Start()
    {
        Vector3 rootCardPosition = cardObject.transform.position;
        Shuffle();
        int counter = 0;
        for (int i = 0; i < col; i++)
        {
            CardObject card;
            for(int j = 0; j < row; j++)
            {
                if (i == 0 && j == 0)
                {
                    card = cardObject;
                }
                else
                {
                    card = Instantiate(cardObject); 
                }
               
                card.SetSpriteForCardFront(arrayOfSprite[index[counter]]);
                counter++;
                float posX = (offsetX * i) + rootCardPosition.x;
                float posY = -(offsetY * j) + rootCardPosition.y;
                card.transform.position = new Vector3(posX, posY, rootCardPosition.z);
            }
        }
        CardObject.OnClick += CardObject_OnClick;
    }

    private void CardObject_OnClick(object sender, EventArgs e)
    {
        CardObject cardObject = (CardObject)sender;
        if (cardOpenedFirst == null)
        {
            cardOpenedFirst = cardObject;
        }
        else if (cardOpenedSecond == null && cardOpenedFirst != cardObject)
        {
            cardOpenedSecond = cardObject;  
        }

    }
    public void Update()
    {

        if (cardOpenedFirst != null && cardOpenedSecond != null)
        {
            checkCardTimer -= Time.deltaTime;
            if (checkCardTimer <= 0)
            {
                checkCardTimer = 0.5f;
                CheckTwoCardIsMatch();
            }
            
        }
           
    }
    private void CheckTwoCardIsMatch()
    {
        if(cardOpenedFirst.GetCardFront().GetSpirte() == cardOpenedSecond.GetCardFront().GetSpirte())
        {
            cardOpenedFirst.gameObject.SetActive(false);
            cardOpenedSecond.gameObject.SetActive(false);
            OnMatch?.Invoke(this, EventArgs.Empty);
            numberOfMath++;
            if(numberOfMath == numberOfCard /2)
            {
                OnWin?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {  
            cardOpenedFirst.ShowCardBack();
            cardOpenedSecond.ShowCardBack();
            OnNotMatch?.Invoke(this, EventArgs.Empty);  
            OnRemoveLife?.Invoke(this, EventArgs.Empty);
        }
        cardOpenedFirst = null;
        cardOpenedSecond = null;
        
    }
    private void Shuffle()
    {
        int lengthOfIndexArray = index.Length;
        for(int i = lengthOfIndexArray -1 ; i >= 0; i--)
        {
            int randomNumber = UnityEngine.Random.Range(0, i);
            (index[i], index[randomNumber]) = (index[randomNumber], index[i]);
          //  Debug.Log(index[i]);
        }
    }
    public bool CanClick()
    {
        return (cardOpenedFirst ==null || cardOpenedSecond == null);
    }
}
