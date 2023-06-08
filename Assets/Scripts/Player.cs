using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    private float _moveSpeed; 
    private float _runSpeed = 10f;
    private float _walkSpeed = 3f;
    private float _jumpingSpeed = 2f;
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
    }

    private void MovementPlayer()
    {
        Vector3 inputDirection = new Vector3(0,0,0); //movement direction through inputs
        // forward and backward --> ANIMATION TECHNICALLY HANDLES MOVEMENT
        if(Input.GetKey(KeyCode.W))
        {
            inputDirection.z = +1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            inputDirection.z = -1;
        }
        // left and right
        if(Input.GetKey(KeyCode.A))
        {
            inputDirection.x = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            inputDirection.x = +1;
        }
        // Jump
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

        // apply movement
        transform.position += inputDirection * _moveSpeed * Time.deltaTime;

        // ROTATION of player -> smoothness of rotation with Slerp
        float _rotationSpeed = 10f;
        if (!_isJumping) //if player not jumping, rotate normally
        {
            transform.forward = Vector3.Slerp(transform.forward, inputDirection, Time.deltaTime * _rotationSpeed);
        }
        else // if player is jumping, don't rotate on y-Axis, or player will land on tail
        {
            //Vector3 inputDirectionNoY = new Vector3(inputDirection.x,0,inputDirection.z);
            transform.forward = Vector3.Slerp(transform.forward, new Vector3(inputDirection.x, 0,inputDirection.z), Time.deltaTime * _rotationSpeed);
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
