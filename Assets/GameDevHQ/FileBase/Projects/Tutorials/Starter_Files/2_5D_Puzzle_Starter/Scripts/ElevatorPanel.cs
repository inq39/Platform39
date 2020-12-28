using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField] private MeshRenderer _callButton;
    [SerializeField] private Elevator _elevator; 
    private int _requiredCoins = 8;
    private bool _isElevatorCalled = false;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && (other.GetComponent<Player>().Coins >= _requiredCoins))
            {            
                _callButton.material.color = Color.green;
                _elevator.CallElevator();
                _isElevatorCalled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && _isElevatorCalled == true)
        {
            _callButton.material.color = Color.red;
            _elevator.EntryElevator();
            _isElevatorCalled = false;
        }
    }
}
