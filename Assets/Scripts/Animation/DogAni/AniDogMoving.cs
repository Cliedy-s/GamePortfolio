using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniDogMoving : AniDogBase
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("MovingSpeed", Mathf.Max(Mathf.Abs(player.V), Mathf.Abs(player.H)));
        // player.StickToTerrain();
        player.Move();
        player.Turn();

        if (player.V == 0 && player.H == 0)
        {
            animator.SetInteger("aniIndex", 0);
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
}