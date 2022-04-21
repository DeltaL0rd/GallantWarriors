using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CurrentSceneLoader()
    {
        string currentScene = PlayerPrefs.GetString("CurrentScene", "Level 1");
        SceneManager.LoadScene(currentScene);
    }

    public void StartFromBegining()
    {
        PlayerPrefs.SetString("CurrentScene","Level 1");
    }
}
