using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AniDogBase : StateMachineBehaviour
{
    protected Player player = null;

    /// <summary>
    /// Replace OnStateEnter 
    /// </summary>
    abstract public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
    /// <summary>
    /// Replace OnStateUpdate
    /// </summary>
    abstract public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
    /// <summary>
    /// Replace OnStateExit
    /// </summary>
    abstract public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
            player = animator.gameObject.GetComponent<Player>();

        StateEnter(animator, stateInfo, layerIndex);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateUpdate(animator, stateInfo, layerIndex);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExit(animator, stateInfo, layerIndex);
    }
}
