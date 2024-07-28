using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {  get; private set; }
    private PlayerInputAction playerInputAction;
    public event EventHandler OnPauseGame;
    private void Awake()
    {
        Instance = this;
        playerInputAction = new PlayerInputAction();
    }
    private void Start()
    {
        playerInputAction.Player.Enable();
        playerInputAction.Player.PauseGame.performed += PauseGame_performed;
    }
    private void OnDestroy()
    {
        playerInputAction.Player.PauseGame.performed -= PauseGame_performed;
        playerInputAction.Dispose();
    }
    private void PauseGame_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       OnPauseGame?.Invoke(this, EventArgs.Empty);  
    }
}
