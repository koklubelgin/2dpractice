using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static Vector2 lastCheckPointPos = new Vector2(-3f,5f);
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;
   
     
    public void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        // Move each player to the last checkpoint position
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject Player in players)
        {
            Player.transform.position = lastCheckPointPos;
        }
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        VCam.m_Follow = player.transform;
        PlayerPrefs.GetInt("SelectedCharacter", 0);
    }
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        // Reset isGameOver
        isGameOver = false;
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

