using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Transform _camera;
    private float _moveSpeed; 
    private float _runSpeed = 10f;
    private float _walkSpeed = 3f;
    private float _jumpingSpeed = 3f;
    private int _maxJumps = 2; // only double jumps possible, not triple
    private int _jumpsRemaining; 
    private bool _isJumping = false;
    //private Vector3 inputVector = new Vector3(0,0,0); //movement direction through inputs

    // Update is called once per frame
    void Update()
    {
        // define move speed by checking if shift is being pressed (shift pressed = _runSpeed)
        _moveSpeed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;

        MovementPlayer();


        if (Input.GetMouseButtonDown(0)) //right click on mouse
        {}
    }

    private void MovementPlayer()
    {
        // Player Input - forward/back and left/right 
        float _horizontalInput = Input.GetAxis("Horizontal");
        float _verticalInput = Input.GetAxis("Vertical");

        // Camera direction
        Vector3 _cameraForward = _camera.forward;
        Vector3 _cameraRight = _camera.right;
        // so that player doesn't move upwards/downwards when camera is facing up/down
        _cameraForward.y = 0; 
        _cameraRight.y = 0;
        _cameraForward = _cameraForward.normalized;
        _cameraRight = _cameraRight.normalized;

        // Direction-Relative Input Vectors
        Vector3 _forwardRelativeVerticalInput = _verticalInput * _cameraForward;
        Vector3 _rightRelativeVerticalInput = _horizontalInput * _cameraRight;
        
        // Camera-Relative Movement of Player
        Vector3 _moveDir = _forwardRelativeVerticalInput + _rightRelativeVerticalInput;


        Vector3 inputDirection = new Vector3(0,0,0); //movement direction through inputs (only jumping)
        // Jump and double jump
        if(Input.GetKeyDown("space"))
        {
            // if you have not done a double jump
            if(_jumpsRemaining > 0)
            {
                if(!_isJumping) // if you are not currently jumping
                {
                    // jump, and _isJumping set to true
                    inputDirection.y = +_jumpingSpeed;
                    RB.velocity += inputDirection;
                    _isJumping = true;
                }
                else
                {
                    // you are currently jumping and jump again, _jumpsRemaining is reduced once
                    inputDirection.y = +_jumpingSpeed;
                    RB.velocity += inputDirection;
                    _jumpsRemaining--;
                }
            }
        }

        // normalize, so that diagonal movement not faster
        inputDirection = inputDirection.normalized;
        _moveDir.y = inputDirection.y;

        // apply movement
        transform.position += _moveDir * _moveSpeed * Time.deltaTime;

        // ROTATION of player -> smoothness of rotation with Slerp
        float _rotationSpeed = 10f;
        if (!_isJumping) //if player not jumping, rotate normally
        {
            transform.forward = Vector3.Slerp(transform.forward, _moveDir, Time.deltaTime * _rotationSpeed);
        }
        else // if player is jumping, don't rotate on y-Axis, or player will land on tail
        {
            transform.forward = Vector3.Slerp(transform.forward, new Vector3(_moveDir.x, 0,_moveDir.z), Time.deltaTime * _rotationSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision) // always called if ground is touched
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false; // player not jumping anymore
            _jumpsRemaining = _maxJumps-1; //if you jump once, you always only have 1 jump remaining
        }
    }
}
