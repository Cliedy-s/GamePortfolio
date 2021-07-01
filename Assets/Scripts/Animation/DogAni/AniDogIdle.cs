
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniDogIdle : AniDogBase
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.V != 0 || player.H != 0)
        {
            animator.SetInteger("aniIndex", 1);
        }
        if (player.Attack)
        {
            animator.SetInteger("aniIndex", 2);
        }
        if (player.Defence)
        {
            animator.SetInteger("aniIndex", 7);
        }
        if (player.IsTryJump)
        {
            animator.SetInteger("aniIndex", 5);
        }
        if (player.IsTryDodge)
        {
            animator.SetInteger("aniIndex", 8);
        }
    }
    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
