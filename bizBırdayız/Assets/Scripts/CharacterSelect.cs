using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters;
    public Button unlockButton;
    public TextMeshProUGUI coinsText;
    private int price;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);
        skins[selectedCharacter].SetActive(true);

        foreach(Character c in characters)
        {
            if (c.price == 0)
                c.isUnLocked = true;
            else
            {
                
        
                c.isUnLocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();

    }
    public void ChangeNext()
    {

        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;
        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnLocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    }





    public void ChanegePrevious()
    {

        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;
        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnLocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
       

        UpdateUI();
    }
    public void UpdateUI()
    {

        coinsText.text = "Price:" + PlayerPrefs.GetInt("NumberOfCoins", 0);
        if (characters[selectedCharacter].isUnLocked == true)
            unlockButton.gameObject.SetActive(false);
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price:" + characters[selectedCharacter].price;
                if(PlayerPrefs.GetInt("NumberOfCoins",0) < characters[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;

            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void Unlock()
    {



        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int pricee = characters[selectedCharacter].price;
        PlayerPrefs.SetInt("NumberOfCoins", coins - price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnLocked = true;
        UpdateUI();

    }



}
