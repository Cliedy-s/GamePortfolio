using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniTrollRun : AniBase<TrollGiant>
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
        baseObj.DetectPlayer();
        if (!baseObj.IsMoving)
            aniIndex = 0;
        if (baseObj.IsHitDis)
            aniIndex = 2;
        if (baseObj.IsAttacked)
            aniIndex = 3;
        if (baseObj.IsDie)
            aniIndex = 4;

        Debug.Log(aniIndex);
        animator.SetInteger("aniIndex", aniIndex);
    }
}
