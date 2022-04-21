using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubmitScore : MonoBehaviour
{
    public GameObject Loader;
    public Text errorTxt;
    public InputField NameIF;
    private void OnEnable()
    {
        NameIF.text = PlayerPrefs.GetString("UserName");
    }

    public void SubmitTheScore()
    {
        if (NameIF.text != "")
        {
            PlayerPrefs.SetString("UserName", NameIF.text);
            StartCoroutine(GetUserIdRoutine());
        }
    }

    IEnumerator GetUserIdRoutine()
    {
        Loader.SetActive(true);

        if (PlayerPrefs.GetString("UserId") == "")
        {
            using (UnityWebRequest www = UnityWebRequest.Get(APIEndPoint.URL + "api/user/req_userid"))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    errorTxt.text = www.error;
                    Loader.SetActive(false);
                }
                else
                {
                    GetUserId Response = JsonUtility.FromJson<GetUserId>(www.downloadHandler.text);
                    if (Response.status == true)
                    {
                        PlayerPrefs.SetString("UserId", Response.data);
                        Debug.Log(Response.data);
                        StartCoroutine(SubmitDetails());
                    }
                    else
                    {
                        errorTxt.text = "An Error Occurred";
                        Loader.SetActive(false);
                    }
                }
            }
        }
        else
        {
            StartCoroutine(SubmitDetails());
        }
    }

    IEnumerator SubmitDetails()
    {
        int TotalScore = PlayerPrefs.GetInt("Level1Score") + PlayerPrefs.GetInt("Level2Score") + PlayerPrefs.GetInt("Level3Score") + PlayerPrefs.GetInt("Level4Score") + PlayerPrefs.GetInt("Level5Score");

        WWWForm form = new WWWForm();
        form.AddField("user_id", PlayerPrefs.GetString("UserId"));
        form.AddField("score", TotalScore);
        form.AddField("name", PlayerPrefs.GetString("UserName"));

        using (UnityWebRequest www = UnityWebRequest.Post(APIEndPoint.URL + "api/user/score_add", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                errorTxt.text = www.error;
                Debug.Log("5");
                Loader.SetActive(false);
            }
            else
            {
                SendScore Response = JsonUtility.FromJson<SendScore>(www.downloadHandler.text);
                if (Response.status == true)
                {
                    Debug.Log("6");
                    errorTxt.color = Color.white;
                    errorTxt.text = "Score Submitted Successfully";
                    Invoke("CloseSumbitPanel", 1f);
                    Loader.SetActive(false);
                }
                else
                {
                    Debug.Log("7");
                    errorTxt.text = "An Error Occurred";
                    Loader.SetActive(false);
                }
            }
        }
    }

    void CloseSumbitPanel()
    {
        SceneManager.LoadScene("Home");
    }
}