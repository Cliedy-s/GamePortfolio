using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBagAnimation : MonoBehaviour
{
    public Animator ani;
    void Start()
    {
        ani.speed = 1f;
    }
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.UpArrow)){
        //     ani.speed = Mathf.Clamp(ani.speed+0.1f, 0.0f, 1f);
        // }
        // if(Input.GetKeyDown(KeyCode.DownArrow)){
        //     // float tmp = ani.speed;
        //     // tmp -= 0.1f;
        //     // ani.speed = Mathf.Clamp(tmp, 0, 3f);
        //     ani.speed = Mathf.Clamp(ani.speed-0.1f, 0.0f, 1f);
        // }
    }
}
