
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //VARIABLES
    [HideInInspector]public int highScore;
    public bool isPaused = false;

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
    }
    #endregion

    public void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
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
