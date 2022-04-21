using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject {

    public int characterId;
    public GameObject characterPrefab;
    public bool isLocked;
    public int price;

}