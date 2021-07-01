using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAttack : MonoBehaviour
{
    public TrollGiant troll;

    private void OnTriggerEnter(Collider other)
    {
        if (troll.IsTryHit)
            troll.OnAttack(other);
    }
}
