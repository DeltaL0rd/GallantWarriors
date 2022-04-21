using UnityEngine;
using UnityEngine.UI;

public class LeaderboardCard : MonoBehaviour
{
    public Text rankTxt, nameTxt, scoreTxt;

    public void ShowData(int rank, string name, int score)
    {
        rankTxt.text = rank.ToString();
        nameTxt.text = name;
        scoreTxt.text = score.ToString();
    }
}
