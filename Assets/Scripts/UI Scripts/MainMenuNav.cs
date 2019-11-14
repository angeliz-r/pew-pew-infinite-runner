using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNav : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Exit;

    public void OpenOptions()
    {
        Options.SetActive(true);

        MainMenu.SetActive(false);
        Exit.SetActive(false);
        Credits.SetActive(false);
    }

    public void OpenCredits()
    {
        Credits.SetActive(true);
        Options.SetActive(false);
        MainMenu.SetActive(false);
        Exit.SetActive(false);
    }

    public void OpenExit()
    {
        Exit.SetActive(true);

        Credits.SetActive(false);
        Options.SetActive(false);
        MainMenu.SetActive(false);

    }

    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        Options.SetActive(false);
        Exit.SetActive(false);
    }

    public void OpenGameScene()
    {
        Loader.Load(Loader.Scene.Game);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
