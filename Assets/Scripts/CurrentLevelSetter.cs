using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentLevelSetter : MonoBehaviour
{
    void Start()
    {
        string currentScene= SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("CurrentScene", currentScene);
    }

}
