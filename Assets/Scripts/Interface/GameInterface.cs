using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    public TextMeshProUGUI coinsText;

    public void SetCoinsText(int coins)
    {
        coinsText.text = coins.ToString();
    }
}