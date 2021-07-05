using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniDogJump : AniDogBase
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // player.TryJump();
    }
    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.Move();
        if (player.V == 0 && player.H == 0)
        {
            animator.SetInteger("aniIndex", 0);
        }
        if (player.V != 0 || player.H != 0)
        {
            animator.SetInteger("aniIndex", 1);
        }
        if (player.IsTryDodge)
        {
            animator.SetInteger("aniIndex", 8);
        }
    }
}
