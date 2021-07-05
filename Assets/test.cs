using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Animator ani;
    public TrollGiant troll;
    void Update()
    {
        Debug.Log($"troll.IsMoving troll.IsAttacked troll.IsHitDis troll.IsTryHit troll.IsDie ");
        Debug.Log($"{troll.IsMoving}{troll.IsAttacked}{troll.IsHitDis}{troll.IsTryHit}{troll.IsDie}");
        // Debug.Log(ani.GetInteger("aniIndex"));
    }
    // custom functions
}
