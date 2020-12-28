using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    private bool _canWallJump = false;
    [SerializeField]
    public int Coins { get; private set; }
    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;
    private Vector3 _velocity, _direction, _wallSurfaceNormal;
    private float _pushPower = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL."); 
        }

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        
        if (_controller.isGrounded == true)
        {
            
            _direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_canWallJump)
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && _canWallJump)
            {
                _yVelocity = _jumpHeight;
                _velocity = _wallSurfaceNormal * _speed;
                _canWallJump = false;
            }

            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "MovingBox" && _controller.isGrounded)
        {
            Rigidbody boxRb = hit.transform.GetComponent<Rigidbody>();
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
            
            if (boxRb != null)
            {
                boxRb.velocity = pushDirection * _pushPower;
            }
        }

        if (hit.transform.tag == "Wall" && !_controller.isGrounded)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallSurfaceNormal = hit.normal;
            _canWallJump = true;
        }
    }

    public void AddCoins()
    {
        Coins++;

        _uiManager.UpdateCoinDisplay(Coins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
