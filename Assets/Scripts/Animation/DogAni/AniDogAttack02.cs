using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniDogAttack02 : AniDogBase
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.Attack)
        {
            animator.SetInteger("aniIndex", 2);
        }
        else if (!player.Attack)
        {
            if (player.V == 0 && player.H == 0)
            {
                animator.SetInteger("aniIndex", 0);
            }
            else if (player.V != 0 || player.H != 0)
            {
                animator.SetInteger("aniIndex", 1);
            }
            if (player.IsTryJump)
            {
                animator.SetInteger("aniIndex", 5);
            }
            if (player.IsTryRoll)
            {
                animator.SetInteger("aniIndex", 8);
            }
        }
    }
}
