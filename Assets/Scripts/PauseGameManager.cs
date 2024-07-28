using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameManager : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    public static PauseGameManager Instance { get; private set; }
    private bool isPauseGame;
    public event EventHandler<OnShowPauseGameEventArg> OnShowPauseGame;
    
 
    public class OnShowPauseGameEventArg : EventArgs
    {
        public bool isPauseGame;
    }
    private void Awake()
    {
        Instance = this;
        isPauseGame = false;
        
    }
    private void Start()
    {       
        InputManager.Instance.OnPauseGame += InputManager_OnPauseGame;
    }
    private void InputManager_OnPauseGame(object sender, System.EventArgs e)
    {
        isPauseGame = !isPauseGame;
        OnShowPauseGame?.Invoke(this, new OnShowPauseGameEventArg
        {
            isPauseGame = isPauseGame
        });
        
    }
    public void HandelPauseButton()
    {
        isPauseGame = false;
        OnShowPauseGame?.Invoke(this, new OnShowPauseGameEventArg
        {
            isPauseGame = isPauseGame
        });
    }
    public bool IsPauseGame()
    {
        return isPauseGame == true;
    }
    public void SetPauseGame(bool isPauseGame)
    {
        this.isPauseGame = isPauseGame;
    }
}
