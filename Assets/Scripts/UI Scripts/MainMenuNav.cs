using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuNav : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Exit;
    [SerializeField] private TextMeshProUGUI ErrorMessage;
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private GameObject warn;

    public void OpenOptions()
    {
        Options.SetActive(true);

        MainMenu.SetActive(false);
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
        Options.SetActive(false);
    }

    public void OpenGameScene()
    {
        if (userName.text != "")
        {
            warn.SetActive(false);
            Loader.Load(Loader.Scene.Game);
        }
        else
        {
            ErrorMessage.text = "Enter a name first!";
            warn.SetActive(true);
        }
            
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
