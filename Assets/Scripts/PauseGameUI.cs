using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameUI : MonoBehaviour
{
    
    private void Start()
    {
        Hide();
        PauseGameManager.Instance.OnShowPauseGame += PauseGameManager_OnShowPauseGame;
    }

    private void PauseGameManager_OnShowPauseGame(object sender, PauseGameManager.OnShowPauseGameEventArg e)
    {
        if(e.isPauseGame)
        {
            Show();
        }
        else
        {
            Hide();
        }
        //PauseGameManager.Instance.OnShowPauseGame -= PauseGameManager_OnShowPauseGame;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
        
    }
    
}
