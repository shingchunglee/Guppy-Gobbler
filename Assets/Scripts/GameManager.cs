using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    public Text scoreText;

    public SoundManager soundManager;
    public HighScoreController highScoreController = new HighScoreController();

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
        score = 2;
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
}
