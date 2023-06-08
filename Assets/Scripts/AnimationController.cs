using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); // get object at start
    }

    // Update is called once per frame
    void Update()
    {
        //bool _walkingKeysPressed = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        // WALKING ANIMATION        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) )
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // if shift is pressed with w,s,d,a -> character animation should run
                _animator.SetBool("isRunning", true); 
            }
            else
            {
                // if w or s is pressed, walking animation should be triggered
                _animator.SetBool("isWalking", true);
            }
            
        }
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) )) //if neither w nor s pressed, back to idle animation
        {
            // if w or s is pressed, walking animation should be triggered
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isRunning", false); // running bool automatically false, if player not walking
        }

        if(Input.GetKeyDown("space")) // if space is pressed, jump animation triggered (boolean set to true)
        {
            _animator.SetBool("isJumping", true);
        }
        if(!Input.GetKeyDown("space")) // if space not pressed, jump animation boolean set to false
        {
            _animator.SetBool("isJumping", false);
        }
    }
}
