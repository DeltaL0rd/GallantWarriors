using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseScreen, GamePlayScreen;

    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        GamePlayScreen.SetActive(false);
        GameObject.Find("UI(Clone)").transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        GamePlayScreen.SetActive(true);
        GameObject.Find("UI(Clone)").transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        GamePlayScreen.SetActive(true);
        GameObject.Find("UI(Clone)").transform.GetChild(0).gameObject.SetActive(true);
        string currentScene = PlayerPrefs.GetString("CurrentScene", "Level 1");
        SceneManager.LoadScene(currentScene);
    }

    public void Home()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        GamePlayScreen.SetActive(true);
        Destroy(GameObject.Find("UI(Clone)"));
        SceneManager.LoadScene("Home");
    }
}
