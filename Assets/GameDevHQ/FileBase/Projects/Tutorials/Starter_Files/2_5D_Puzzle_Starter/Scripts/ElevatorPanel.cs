using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _callButton;
    private int _requiredCoins = 8;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && (other.GetComponent<Player>().Coins >= _requiredCoins))
            {            
                _callButton.material.color = Color.green;
            }
        }
    }
}
