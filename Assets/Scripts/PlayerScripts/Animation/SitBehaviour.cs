using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitBehaviour : StateMachineBehaviour
{
    //how much time should pass (can be set in inspector)
    [SerializeField]
    private float _timeUntilSit;

    // how many animations are in the blendtree (can be set in inspector)
    [SerializeField]
    private int _numberOfSitAnimations;
    // keep track if character is sitting
    private bool _isSitting = false;
    // look into how long the character is idle
    private float _sittingTime;
    // field to store animation where we want to transition to
    private int _sitAnimation;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetSit(); //always reset first when we enter this state
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   // check if fox sitting
        if (_isSitting == false) // if not sitting
        {
            // if not sitting, Idle time increased
            _sittingTime += Time.deltaTime; // add time to _sittingTime

            //check if long enough in Idle to sit down
            if (_sittingTime > _timeUntilSit && stateInfo.normalizedTime % 1 < 0.02f) // if _sittingTime is greater than time
                                                                                      // we want fox to sit set Sitting to true
                                                                                      //only switch when at beginning of animation

            {
                _isSitting = true;
                _sitAnimation = Random.Range(1, _numberOfSitAnimations + 1);   //get random number out of number of animations,
                                                                               //minimum number 1, maximum number of range not included therefore +1
                _sitAnimation = _sitAnimation * 2 - 1; // to get right animation

                // instantly set to next default animation 
                animator.SetFloat("Sit", _sitAnimation - 1);
            }
        } // switch back to normal idle animation
        else if (stateInfo.normalizedTime % 1 > 0.98) // module to look if at end of animation,
                                                      // stateInfo to check normalized time of animation,
                                                      // know how far through animation
        {
            ResetSit(); // reset to default annimation
        }
        //transition to number stored in field, move to the animation gradually
        animator.SetFloat("Sit", _sitAnimation, 0.2f, Time.deltaTime);
    }

    private void ResetSit() //resetting to default animation
    {
        // check if sitting
        if (_isSitting)
        {  // go back to nearest default animation
            _sitAnimation--;
            return;
        }
        _isSitting = false;
        _sittingTime = 0;
    }
}
