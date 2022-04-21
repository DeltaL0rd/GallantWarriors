using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelContinueDetails : MonoBehaviour
{
    public CoinManager coinManager;
    public Timer timer;
    public Text coinAddedTxt;
    public ScoreScript Score;

    private void OnEnable()
    {
        coinAddedTxt.text = "Coins Added: " + coinManager.levelCoins;
        Score.UpdateScore();
    }
}
