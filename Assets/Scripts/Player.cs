using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;
    [SerializeField] private Vector3 _velocity;
    private CharacterController _cc;
    private Animator _playerAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.LogError("Character controller is null.");
        }

        _playerAnimatorController = GetComponentInChildren<Animator>();
        if (_playerAnimatorController == null)
        {
            Debug.LogError("Animator is null.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (_cc.isGrounded)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _playerAnimatorController.SetFloat("Speed", Mathf.Abs(horizontalInput));
            Vector3 direction = new Vector3(0, 0, horizontalInput);
            _velocity = direction * _playerSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y += _jumpHeight;
            }

        }

        _velocity.y += _gravity * Time.deltaTime;
        _cc.Move(_velocity * Time.deltaTime);
    }
}

