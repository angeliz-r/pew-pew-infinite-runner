using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI highScoreRetryText;

    [Header("Player")]
    public GameObject player;
    private PlayerMotor playerScript;
    //score
    protected float currentScore = 0;
    protected float highScore = 0;

    //difficulty things
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel;

    private bool callOnce = false;
    private PauseMenuNav menuScript;

    // Start is called before the first frame update
    void Awake()
    {
        playerScript = player.GetComponent<PlayerMotor>();
        menuScript = this.gameObject.GetComponent<PauseMenuNav>();
        CheckForHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isDead)
        {
            if (!callOnce)
            {
                PlayerDeath();
                callOnce = true;
            }
        }
        if (!playerScript.isDead)
        {
            if (currentScore >= scoreToNextLevel)
            {
                LevelUp();
            }
            currentScore += Time.deltaTime * difficultyLevel;
            scoreText.text = ((int)currentScore).ToString();
        }
    }

    private void LevelUp ()
    {
        //if difficulty maxed out just return the same
        if (difficultyLevel == maxDifficultyLevel)
            return;
        
        scoreToNextLevel *= 2;
        difficultyLevel++;
        playerScript.SetSpeed(difficultyLevel);
    }

    private void PlayerDeath()
    {
        menuScript.RetryGame();
        GameManager.instance.CompareScores((int)currentScore);
        highScoreText.text = GameManager.instance.GetHighScore().ToString();
        highScoreRetryText.text = GameManager.instance.GetHighScore().ToString();
        SaveManager.instance.Save();
    }

    private void CheckForHighScore()
    {
        highScore = GameManager.instance.GetHighScore();
        if (highScore == 0)
        {
            highScoreText.text = "0000";
            highScoreRetryText.text = "0000";
        }
        else
        {
            highScoreText.text = GameManager.instance.GetHighScore().ToString();
            highScoreRetryText.text = GameManager.instance.GetHighScore().ToString();
        }
    }

}
