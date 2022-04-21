using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject StartScreen, CharacterSelector, HelpScreen, LeaderboardScreen;
    
    public GameObject muteObject;
    
    private void Start()
    {
        if (PlayerPrefs.GetInt("IsMusic")==1)
        {
            SingletonScript.Instance.audioSource.mute = true;
            muteObject.SetActive(true);
        }
        else
        {
            SingletonScript.Instance.audioSource.mute = false;
            muteObject.SetActive(false);
        }
    }

    public void OpenStartScreen()
    {
        StartScreen.SetActive(true);
        CharacterSelector.SetActive(false);
        HelpScreen.SetActive(false);
        LeaderboardScreen.SetActive(false);
    }

    public void OpenCharacterScreen()
    {
        StartScreen.SetActive(false);
        CharacterSelector.SetActive(true);
        HelpScreen.SetActive(false);
        LeaderboardScreen.SetActive(false);
    }

    public void OpenHelpScreen()
    {
        StartScreen.SetActive(false);
        CharacterSelector.SetActive(false);
        HelpScreen.SetActive(true);
        LeaderboardScreen.SetActive(false);
    }

    public void OpenLeaderboardScreen()
    {
        StartScreen.SetActive(false);
        CharacterSelector.SetActive(false);
        HelpScreen.SetActive(false);
        LeaderboardScreen.SetActive(true);
    }

    public void ToggleMusic()
    {
        if (PlayerPrefs.GetInt("IsMusic")==0)
        {
            SingletonScript.Instance.audioSource.mute = true;
            muteObject.SetActive(true);
            PlayerPrefs.SetInt("IsMusic",1);
        }
        else
        {
            SingletonScript.Instance.audioSource.mute = false;
            muteObject.SetActive(false);
            PlayerPrefs.SetInt("IsMusic",0);
        }
    }
}
