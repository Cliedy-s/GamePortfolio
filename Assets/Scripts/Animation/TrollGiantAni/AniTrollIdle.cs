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
        // TODO - 거리에따라 움직이고, 공격하는 트롤 애니메이션 구현하기 7/2
        if (baseObj.IsMoving)
            animator.SetInteger("aniIndex", 0);
        if (baseObj.IsHit)
            animator.SetInteger("aniIndex", 3);
        if(baseObj.IsHitDis)
            animator.SetInteger("aniIndex", 2);
        if(baseObj.IsDie)
            animator.SetInteger("aniIndex", 4);
    }
}
