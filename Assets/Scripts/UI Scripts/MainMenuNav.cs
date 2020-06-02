using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuNav : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    public TextMeshProUGUI ErrorMessage;
    public TMP_InputField userName;
    public GameObject warn;


    public void OpenCredits()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
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
