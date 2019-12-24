using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuNav : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PauseContent;
    [SerializeField] private GameObject ExitContent;
    [SerializeField] private GameObject RetryMenu;

    public void PauseGame()
    {
        if (GameManager.instance.isPaused)
        {
            GameManager.instance.isPaused = false;
            Back();
        }
        else
        {
            GameManager.instance.isPaused = true;
            OpenPauseMenu();
        }
    }

    public void RetryGame()
    {
        if (GameManager.instance.isPaused)
        {
            GameManager.instance.isPaused = false;
            Back();
        }
        else
        {
            GameManager.instance.isPaused = true;
            OpenRetryMenu();
        }
    }
    public void OpenRetryMenu()
    {
        PauseMenu.SetActive(false);
        PauseContent.SetActive(false);
        ExitContent.SetActive(false);
        RetryMenu.SetActive(true);
    }
    public void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
        PauseContent.SetActive(true);
        ExitContent.SetActive(false);
        RetryMenu.SetActive(false);
    }
    public void OpenExitMenu()
    {
        PauseMenu.SetActive(true);
        PauseContent.SetActive(false);
        ExitContent.SetActive(true);
        RetryMenu.SetActive(false);
    }

    public void Back()
    {
        PauseMenu.SetActive(false);
        PauseContent.SetActive(false);
        ExitContent.SetActive(false);
        RetryMenu.SetActive(false);
    }
    public void OpenMainMenuScene()
    {
        GameManager.instance.isPaused = false;
        Loader.Load(Loader.Scene.MainMenu);
    }
    public void ReloadGame()
    {
        GameManager.instance.isPaused = false;
        Loader.Load(Loader.Scene.Game);
    }

}
