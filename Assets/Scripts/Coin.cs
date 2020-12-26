using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>(); 

            if (player != null)
            {
                player.UpdateCollectedCoins(_coinValue);
            }
            //instantiate explosion
            Destroy(this.gameObject);
        }
    }
}
