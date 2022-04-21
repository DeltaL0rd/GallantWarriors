using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public bool IsFirstLevel;

    public string CurrentLevel;
    public Text LevelScoreText, TotalScoreText;
    public GameObject SubmitToLeaderboardBtn;
    string LevelNameScore;
    public Timer TimeScript;
    public GameObject submitScorePanel;
    void Start()
    {
        LevelNameScore = "Level" + CurrentLevel + "Score";
        if (IsFirstLevel == true)
        {
            PlayerPrefs.SetInt(LevelNameScore, 0);
        }

        PlayerPrefs.SetInt("ItemPickups", 0);
    }

    public void UpdateScore()
    {
        int ItemScore = PlayerPrefs.GetInt("ItemPickups")*10;
        int Score = (int)(TimeScript.timeRemaining) + ItemScore;
        PlayerPrefs.SetInt(LevelNameScore, Score);
        int TotalScore = PlayerPrefs.GetInt("Level1Score") + PlayerPrefs.GetInt("Level2Score") + PlayerPrefs.GetInt("Level3Score") + PlayerPrefs.GetInt("Level4Score") + PlayerPrefs.GetInt("Level5Score");
        if (CurrentLevel =="5" && TotalScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",TotalScore);
            SubmitToLeaderboardBtn.SetActive(true);
            
        }
        else
        {
            SubmitToLeaderboardBtn.SetActive(false);
        }
        LevelScoreText.text = "Level Score: " + Score.ToString();
        TotalScoreText.text = "Total Score: " + TotalScore.ToString();
    }
}