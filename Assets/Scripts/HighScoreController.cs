using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class HighScoreController : MonoBehaviour
{
    private string[] PPrefsHSNames = {
        "HScore1",
        "HScore2",
        "HScore3",
        "HScore4",
        "HScore5",
        "HScore6",
        "HScore7",
        "HScore8",
        "HScore9",
        "HScore10"
        };

    private int[] highScores = new int[10];

    public TMP_InputField inputField;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        LoadScoresIfExist();
    }

    private void ScoreWithInputField()
    {
        if (inputField == null)
        {
            Debug.Log("No input field configured.");
            return;
        }

        int score = int.Parse(inputField.text);
        SubmitScore(score);

    }

    public void SubmitScore(int score)
    {
        LoadScoresIfExist();

        //If the new high score is greater than the lowest highscore it is saved.
        if (score > highScores[9])
        {
            highScores[9] = score;
        }

        highScores = highScores.OrderByDescending(x => x).ToArray();

        // DisplayHighScores();

        SaveHighScores();
    }

    private void DisplayHighScores()
    {
        highScoreText.text =
            $"1. {highScores[0]} \n" +
            $"2. {highScores[1]} \n" +
            $"3. {highScores[2]} \n" +
            $"4. {highScores[3]} \n" +
            $"5. {highScores[4]} \n" +
            $"6. {highScores[5]} \n" +
            $"7. {highScores[6]} \n" +
            $"8. {highScores[7]} \n" +
            $"9. {highScores[8]} \n" +
            $"10. {highScores[9]}";
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt(PPrefsHSNames[i], highScores[i]);
        }
        PlayerPrefs.Save();
    }

    private void LoadScoresIfExist()
    {
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(PPrefsHSNames[i]))
            {
                highScores[i] = PlayerPrefs.GetInt(PPrefsHSNames[i]);
            }
            else
            {
                Debug.Log($"No score exists for score: {i}.");
                highScores[i] = 0;
            }
        }

        DisplayHighScores();
    }

    public void ScoreButton()
    {
        ScoreWithInputField();
    }

    public void ResetButton()
    {
        for (int i = 0; i < 10; i++)
        {
            highScores[i] = 0;
            PlayerPrefs.SetInt(PPrefsHSNames[i], 0);
        }
        PlayerPrefs.Save();

        DisplayHighScores();
    }
}
