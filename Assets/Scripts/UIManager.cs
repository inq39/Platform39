using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _collectedCoinsText;
    [SerializeField] private TextMeshProUGUI _livesText;


    public void UpdateCollectedCoinsText(int collectedCoins)
    {
        _collectedCoinsText.SetText("Coins collected: " + collectedCoins);
    }

    public void UpdateLivesText(int remainingLives)
    {
        _livesText.SetText("Lives remaining: " + remainingLives);
    }
}
