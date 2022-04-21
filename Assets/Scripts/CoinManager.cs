using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text CoinText;
    public int levelCoins;

    public void AddCoin(int count)
    {
        levelCoins = levelCoins + count;
        CoinText.text = levelCoins.ToString();

        int totalCoins = PlayerPrefs.GetInt("TotalCoins");
        totalCoins = totalCoins + count;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }
}