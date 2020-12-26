using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 0.3f;
    [SerializeField] private float _jumpHeight = 25.0f;
    private float _yVelocity;
    private bool _doubleJumpAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
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

