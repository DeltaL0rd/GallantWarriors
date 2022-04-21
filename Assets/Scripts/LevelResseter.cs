using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResseter : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerPrefs.SetString("CurrentScene", "Level 1");
    }
}
