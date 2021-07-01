using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AniBase<T> : StateMachineBehaviour
{
    protected T baseObj;

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
        if (baseObj == null)
            baseObj = animator.gameObject.GetComponent<T>();

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
