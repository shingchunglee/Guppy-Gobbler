using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    public Text scoreText;

    public SoundManager soundManager;
    public HighScoreController highScoreController;

    public GameObject gameOverScreen;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public int score { private set; get; }

    public void AddScore(int newScore)
    {
        score += newScore;
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void SaveScore()
    {
        highScoreController.SubmitScore(score);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void GameOverPanelOff()
    {
        gameOverScreen.SetActive(false);
    }

    public void DoneButton()
    {
        Debug.Log("Done!");
        SceneManager.LoadSceneAsync(0);
    }



}
