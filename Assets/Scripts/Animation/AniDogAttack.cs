using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniDogAttack : AniDogBase
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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
        }
    }
}
