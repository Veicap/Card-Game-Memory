using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadSceneLv1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSceneLv2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadSceneLv3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadSceneLv4()
    {
        SceneManager.LoadScene(4);
    }
}
