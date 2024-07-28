using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WingameUI : MonoBehaviour
{
    private void Start()
    {
        Hide();
        CardManager.Instance.OnWin += CardManager_OnWin;
    }

    private void CardManager_OnWin(object sender, System.EventArgs e)
    {
        Show();
    }
    private void Hide()
    {
        gameObject.SetActive(false);

    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
