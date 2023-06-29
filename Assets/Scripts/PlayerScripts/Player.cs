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
    private float _jumpingSpeed = 3.5f;
    private int _maxJumps = 2; // only double jumps possible, not triple
    private int _jumpsRemaining; 
    private bool _isJumping = false;
    

    // Update is called once per frame
    private void Update()
    {
        // define move speed by checking if shift is being pressed (shift pressed = _runSpeed)
        _moveSpeed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;

        MovementPlayer(); // move player
    }
    
    private void BarkingFox()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            FindObjectOfType<AudioManager>().Play("FoxBark");
        }

    }
    private void MovementPlayer()
    {
        BarkingFox();

        // WALKING
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
        
        // JUMPING
        //movement direction for jumping
        Vector3 _jumpVectorDir = new Vector3(0,0,0);
        // Jump and double jump
        if(Input.GetKeyDown("space"))
        {
            // if you have not done a double jump
            if(_jumpsRemaining > 0)
            {
                if(!_isJumping) // if you are not currently jumping
                {
                    // jump, and _isJumping set to true
                    _jumpVectorDir.y = +_jumpingSpeed;
                    RB.velocity += _jumpVectorDir;
                    _isJumping = true;
                }
                else
                {
                    // you are currently jumping and jump again, _jumpsRemaining is reduced once
                    _jumpVectorDir.y = +_jumpingSpeed;
                    RB.velocity += _jumpVectorDir;
                    _jumpsRemaining--;
                }
            }
        }

        // normalize, so that diagonal movement not faster, set y of moveDir to y of jumpVectorDir
        _jumpVectorDir = _jumpVectorDir.normalized;
        _moveDir.y = _jumpVectorDir.y;

        // APPLY MOVEMENT
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
