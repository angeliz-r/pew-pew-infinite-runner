
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public PlayerData data;
    public int highScore;
    [Header("Name Data")]
    public TMP_InputField userName;
    public string playerName;

    [HideInInspector]public bool isPaused = false;
    private Scene scene;
   

    //a singleton is an instance that keeps this script and everything inside this script
    //saved throughout the game.
    #region SINGLETON
    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        isPaused = false;
        data = new PlayerData();
        playerName = "";
        SaveManager.instance.Load();

        if (playerName != null)
        {
            userName.text = playerName;
        }
    }
    #endregion

    public PlayerData CopyToSaveData()
    {
        data.highScore = highScore;
        data.playerName = playerName;
        return data;
    }

    public void LoadFromSaveData (PlayerData data)
    {
        highScore = data.highScore;
        playerName = data.playerName;
    }
    public void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            if (userName == null)
                userName = GameObject.FindGameObjectWithTag("Input").GetComponent<TMP_InputField>();

            EnterName();
        }
            
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void EnterName ()
    {
       
        playerName = userName.text;
        SaveManager.instance.Save();
    }

    public string GetName()
    {
        return playerName;
    }

    public void CompareScores(int currentScore)
    {
        if (highScore == 0)
            highScore = currentScore;
        else if (highScore < currentScore)
            highScore = currentScore;
    }
    public int GetHighScore()
    {
        return highScore;
    }


}
