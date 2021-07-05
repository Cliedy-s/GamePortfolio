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
            animator.SetInteger("aniIndex", 0);
        if (baseObj.IsHitDis)
            animator.SetInteger("aniIndex", 2);
        if (baseObj.IsAttacked)
            animator.SetInteger("aniIndex", 3);
        if (baseObj.IsDie)
            animator.SetInteger("aniIndex", 4);

    }
}
