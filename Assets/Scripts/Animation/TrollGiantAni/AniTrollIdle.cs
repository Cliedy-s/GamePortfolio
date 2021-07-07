using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTrollIdle : AniBase<TrollGiant>
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        baseObj.DetectPlayer();
        if (baseObj.IsMoving)
            animator.SetInteger("aniIndex", 1);
        if(baseObj.IsHitDis)
            animator.SetInteger("aniIndex", 2);
        if (baseObj.IsAttacked)
            animator.SetInteger("aniIndex", 3);
        if(baseObj.IsDie)
            animator.SetInteger("aniIndex", 4);

    }
}
