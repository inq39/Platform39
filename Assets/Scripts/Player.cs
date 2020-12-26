using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 0.3f;
    [SerializeField] private float _jumpHeight = 25.0f;
    [SerializeField] private UIManager _uiManager;
    private float _yVelocity;
    private bool _doubleJumpAllowed;
    private int _collectedCoins; 

    // Start is called before the first frame update
    void Start()
    {
        _collectedCoins = 0;
        _uiManager.UpdateCollectedCoinsText(_collectedCoins);

        _characterController = GetComponent<CharacterController>();

        if (_uiManager == null)
        {
            Debug.LogError("UIManager is null.");
        }
    }
        // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    public void UpdateCollectedCoins(int coins)
    {
        _collectedCoins += coins;
        _uiManager.UpdateCollectedCoinsText(_collectedCoins);

    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _doubleJumpAllowed = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _doubleJumpAllowed)
            {
                _yVelocity += _jumpHeight;
                _doubleJumpAllowed = false;
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _characterController.Move(velocity * Time.deltaTime);
    }
}

