using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderboardScript : MonoBehaviour
{
    public GameObject cardsHolder;
    public GameObject cardPrefab;

    public GameObject Loader;

    public Text errorTxt;

    void OnEnable()
    {
        errorTxt.text = "";
        GetLeaderBoard();
    }

    public void GetLeaderBoard()
    {
        for (int i = 0; i < cardsHolder.transform.childCount; i++)
        {
            Destroy(cardsHolder.transform.GetChild(i).gameObject);
        }

        StartCoroutine(LeaderboardRoutine());
    }

    IEnumerator LeaderboardRoutine()
    {
        Loader.SetActive(true);

        using (UnityWebRequest www = UnityWebRequest.Get(APIEndPoint.URL + "api/user/top_scores"))
        {
            yield return www.SendWebRequest();

            Loader.SetActive(false);

            if (www.isNetworkError || www.isHttpError)
            {
                errorTxt.text = www.error;
            }
            else
            {
                LeaderBoard Response = JsonUtility.FromJson<LeaderBoard>(www.downloadHandler.text);
                if (Response.status == true)
                {
                    if(Response.data.Length>0)
                    {
                        for (int i = 0; i < Response.data.Length; i++)
                        {
                            GameObject card = Instantiate(cardPrefab, cardsHolder.transform);
                            card.GetComponent<LeaderboardCard>().ShowData(i+1, Response.data[i].name, Response.data[i].score);
                        }
                    }
                    else
                    {
                        errorTxt.text = "No Data Yet";
                    }
                }
                else
                {
                    errorTxt.text = "An Error Occurred";
                }
            }
        }
    }

}