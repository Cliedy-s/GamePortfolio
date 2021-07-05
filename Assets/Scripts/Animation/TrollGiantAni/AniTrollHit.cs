using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTrollHit : AniBase<TrollGiant>
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    int aniIndex = 0;
    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!baseObj.IsMoving)
            aniIndex = 0;
        else if(baseObj.IsMoving)
            aniIndex = 1;
        if (baseObj.IsHitDis)
            aniIndex = 2;
        if (baseObj.IsAttacked)
            aniIndex = 3;
        if (baseObj.IsDie)
            aniIndex = 4;

        animator.SetInteger("aniIndex", aniIndex);
    }
}
