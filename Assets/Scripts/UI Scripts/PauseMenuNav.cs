using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuNav : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PauseContent;
    [SerializeField] private GameObject ExitContent;
    private GameManager GameManagerObj;
    private void Start()
    {
        GameManagerObj = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void PauseGame()
    {
        if (GameManagerObj.isPaused)
        {
            GameManagerObj.isPaused = false;
            Back();
        }
        else
        {
            GameManagerObj.isPaused = true;
            OpenPauseMenu();
        }
    }
    public void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
        PauseContent.SetActive(true);
        ExitContent.SetActive(false);
    }
    public void OpenExitMenu()
    {
        PauseMenu.SetActive(true);
        PauseContent.SetActive(false);
        ExitContent.SetActive(true);
    }

    public void Back()
    {
        PauseMenu.SetActive(false);
        PauseContent.SetActive(false);
        ExitContent.SetActive(false);
    }
    public void OpenMainMenuScene()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }

}
