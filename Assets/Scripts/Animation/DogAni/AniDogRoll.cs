using UnityEngine;

public class AniDogRoll : AniDogBase
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.TryDodge();
        player.agent.speed = player.dodgePower;
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.StopPlayerCoroutine(Coroutines.Dodge);
        player.agent.speed = player.moveSpeed;
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
        if (player.IsTryJump)
        {
            animator.SetInteger("aniIndex", 5);
        }
    }
}
