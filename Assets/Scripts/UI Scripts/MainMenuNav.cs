using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuNav : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Exit;
    [SerializeField] private TextMeshProUGUI ErrorMessage;
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private GameObject warn;


    public void OpenCredits()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
        Exit.SetActive(false);
    }

    public void OpenExit()
    {
        Exit.SetActive(true);

        Credits.SetActive(false);
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
