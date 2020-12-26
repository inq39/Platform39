using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _collectedCoinsText;

   

    public void UpdateCollectedCoinsText(int collectedCoins)
    {
        _collectedCoinsText.SetText("Coins collected: " + collectedCoins);
    }
}
