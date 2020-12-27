using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGround : MonoBehaviour
{
    private GameManager _gameManager;
   
    [SerializeField] private GameObject _playerSpawnPoint;

    public void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("_gameManager is null.");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            
            if (player != null)
            {
                player.UpdateLives();
            }

            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                StartCoroutine(EnablePlayerCC(cc));
                other.transform.position = _playerSpawnPoint.transform.position;
            }
        }
    }

    IEnumerator EnablePlayerCC(CharacterController controller)
    {        
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;       
    }
}
