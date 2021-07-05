using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTrollAtk01 : AniBase<TrollGiant>
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        baseObj.IsTryHit = true;
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        baseObj.IsTryHit = false;
    }

    int aniIndex = 0;
    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (baseObj.IsMoving)
            aniIndex = 0;
        if (baseObj.IsHitDis)
            aniIndex = 2;
        if (baseObj.IsAttacked)
            aniIndex = 3;
        if (baseObj.IsDie)
            aniIndex = 4;

        animator.SetInteger("aniIndex", aniIndex);
    }
}
