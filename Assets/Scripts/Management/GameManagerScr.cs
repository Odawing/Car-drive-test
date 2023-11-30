using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr Instance;

    public GameInterface gameInterface;

    public CarController car;

    private int coins;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
    }

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");

        gameInterface.SetCoinsText(coins);
    }

    public void CollectCoin()
    {
        coins++;
        gameInterface.SetCoinsText(coins);
        PlayerPrefs.SetInt("Coins", coins);
    }
}