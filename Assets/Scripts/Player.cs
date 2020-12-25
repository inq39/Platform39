using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed = 5.0f;
    private float _gravity = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(_horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
        
        if (_characterController.isGrounded)
        {
            
        }
        else
        {
            velocity.y -= _gravity;
        }

        _characterController.Move(velocity * Time.deltaTime);
    }
}

