using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAttack : MonoBehaviour
{
    public TrollGiant troll;
    // events
    private void OnTriggerEnter(Collider other)
    {
        if (troll.IsTryHit && other.gameObject.tag == "Player")
            troll.OnAttack(other);
    }
}
