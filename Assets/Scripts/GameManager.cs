using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //VARIABLES
    protected int highScore;
    protected int currentScore;
    public bool isPaused;

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

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 0;
            }
            else
            {
                isPaused = true;
                Time.timeScale = 1;
            }
        }
    }


}
