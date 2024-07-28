using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameUI : MonoBehaviour
{
    private void Start()
    {
        Hide();
        EventManager.Instance.OnLose += EventManager_OnLose;
    }

    private void EventManager_OnLose(object sender, System.EventArgs e)
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
