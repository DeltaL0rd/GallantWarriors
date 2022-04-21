using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] characterPrefab;

    private void Awake()
    {
        GameObject player = Instantiate(characterPrefab[PlayerPrefs.GetInt("CurrentCharacterId")]) as GameObject;
        player.transform.position = transform.position;
    }
}
