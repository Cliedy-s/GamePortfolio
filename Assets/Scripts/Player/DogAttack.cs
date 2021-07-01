using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    public Player player;
    bool isAttacking = false;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    private void OnTriggerEnter(Collider other) {
        if(IsAttacking)
            player.OnAttack(other);
    }
}
