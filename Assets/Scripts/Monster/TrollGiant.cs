using System;
using UnityEngine;
using UnityEngine.AI;

public class TrollGiant : NavMonster
{

    // unity functions
    public override void RunAwake()
    {
    }
    public override void RunStart()
    {
    }
    public override void RunUpdate()
    {
        
    }

    // custom functions

    // Events
    private void OnCollisionEnter(Collision other)
    {
        // TODO - 맞고 때리는거 구현하기
        Debug.Log("attaced...?");
        if (other.gameObject.tag == "Weapon")
        {
            Debug.Log("Attacked!");
        }
    }
}
