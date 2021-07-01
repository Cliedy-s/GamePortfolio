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

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
