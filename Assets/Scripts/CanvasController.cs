using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject PlayScreen, LevelCompleteScreen, DeadScreen;
    public Text CoinText;
    public Text TimeLeftTextA, CoinTextA;

    public void EnableLevelCompleteScreen()
    {
        CoinText.text = "Coins Added: " + CoinTextA.text;
        PlayScreen.SetActive(false);
        LevelCompleteScreen.SetActive(true);
        DeadScreen.SetActive(false);
    }

    public void EnableDeadScreen()
    {
        PlayScreen.SetActive(false);
        LevelCompleteScreen.SetActive(false);
        DeadScreen.SetActive(true);
    }
}