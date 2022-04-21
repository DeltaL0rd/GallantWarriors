using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagerHome : MonoBehaviour
{
    public Text CoinText;
    public int Coins;
    bool justAdded;

    private void Start()
    {
        //PlayerPrefs.SetInt("TotalCoins", 2000);
        Coins = PlayerPrefs.GetInt("TotalCoins");
        CoinText.text = Coins.ToString();
    }

    public void AddCoin(int count)
    {
        StartCoroutine(Add(count));
    }

    IEnumerator Add(int count)
    {
        yield return new WaitForSeconds(0.5f);
        if (justAdded == false)
        {
            justAdded = true;
            Debug.Log("Add 30");
            Coins = Coins + count;
            CoinText.text = Coins.ToString();
            PlayerPrefs.SetInt("TotalCoins", Coins);
            Invoke("Added", 1f);
        }
    }

    void Added()
    {
        justAdded = false;
    }
}