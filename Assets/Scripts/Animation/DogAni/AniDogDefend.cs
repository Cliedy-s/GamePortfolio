using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniDogDefend : AniDogBase
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player.Defence)
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
    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
