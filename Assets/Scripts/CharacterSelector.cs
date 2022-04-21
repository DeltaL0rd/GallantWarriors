using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public Character[] character;

    int currentIndex;

    GameObject currentCharaterModel;
    public int selectedCharacterId;

    public Transform characterParent;
    public GameObject lockImg;

    public GameObject messagePanel;
    public Text messageText;

    public Text selectText;

    public CoinManagerHome CoinManager;

    private void Start()
    {
        selectedCharacterId = PlayerPrefs.GetInt("CurrentCharacterId");
        ChangeModel(0);

        int IndexUnlockedP2 = PlayerPrefs.GetInt("IndexUnlockedP2");
        int IndexUnlockedP3 = PlayerPrefs.GetInt("IndexUnlockedP3");
        int IndexUnlockedP4 = PlayerPrefs.GetInt("IndexUnlockedP4");

        if(IndexUnlockedP2 == 1)
        {
            Debug.Log("aa");
            character[2].isLocked = false;
        }
        if (IndexUnlockedP3 == 1)
        {
            character[3].isLocked = false;
        }
        if (IndexUnlockedP4 == 1)
        {
            character[4].isLocked = false;
        }
    }

    private void OnEnable()
    {
        characterParent.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        characterParent.gameObject.SetActive(false);
    }

    public void NextCharacter()
    {
        Destroy(currentCharaterModel);
        currentIndex += 1;
        if (currentIndex >= character.Length)
        {
            currentIndex = 0;
        }
        ChangeModel(currentIndex);
    }

    public void PreviousCharacter()
    {
        Destroy(currentCharaterModel);
        currentIndex -= 1;
        if (currentIndex < 0)
        {
            currentIndex = character.Length - 1;
        }
        ChangeModel(currentIndex);
    }

    void ChangeModel(int index)
    {
        SetSelectText();
        currentCharaterModel = Instantiate(character[currentIndex].characterPrefab);
        currentCharaterModel.transform.parent = characterParent;
        currentCharaterModel.transform.localPosition = new Vector3(0, 0, 0);
        currentCharaterModel.transform.rotation = characterParent.transform.rotation;
        if (character[index].isLocked == true)
        {
            lockImg.SetActive(true);
            selectText.text = character[currentIndex].price + " Coins";
        }
        else
        {
            lockImg.SetActive(false);
        }
    }

    public void SelectCharacter()
    {
        if (character[currentIndex].isLocked == false)
        {
            selectedCharacterId = currentIndex;
            SetSelectText();
            PlayerPrefs.SetInt("CurrentCharacterId", currentIndex);
            Debug.Log("Character Selected");
        }
        else
        {
            if (CoinManager.Coins > character[currentIndex].price)
            {
                string PrefName = "IndexUnlockedP" + currentIndex;
                PlayerPrefs.SetInt(PrefName, 1);
                character[currentIndex].isLocked = false;
                lockImg.SetActive(false);
                SelectCharacter();
                
                CoinManager.Coins = CoinManager.Coins - character[currentIndex].price;
                CoinManager.CoinText.text = CoinManager.Coins.ToString();
                PlayerPrefs.SetInt("TotalCoins", CoinManager.Coins);
            }
            else
            {
                messagePanel.SetActive(true);
                messageText.text = "Insufficient Coins";
            }
        }
    }

    void SetSelectText()
    {
        if (currentIndex == selectedCharacterId)
        {
            selectText.text = "Selected";
        }
        else
        {
            selectText.text = "Select";
        }
    }
}