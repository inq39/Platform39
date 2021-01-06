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
    private bool _isJumping = false;

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
        CalculateMovement();            
                        
    }

    public void UpdateLedgeStatus(Vector3 handpos)
    {
        _cc.enabled = false;
        _playerAnimatorController.SetBool("Hanging", true);
        transform.position = handpos;
    }

    private void CalculateMovement()
    {
        if (_cc.isGrounded)
        {
            if (_isJumping)
            {
                _isJumping = false;
                _playerAnimatorController.SetBool("Jumping", _isJumping);
            }

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _playerAnimatorController.SetFloat("Speed", Mathf.Abs(horizontalInput));
            Vector3 direction = new Vector3(0, 0, horizontalInput);
            _velocity = direction * _playerSpeed;

            if (horizontalInput != 0)
            {
                Vector3 flipping = transform.localEulerAngles;
                flipping.y = direction.z > 0 ? 0 : 180;
                transform.localEulerAngles = flipping;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = true;
                _velocity.y += _jumpHeight;
                _playerAnimatorController.SetBool("Jumping", _isJumping);
            }

        }
                
        _velocity.y += _gravity * Time.deltaTime;
        _cc.Move(_velocity * Time.deltaTime);
    }
}

