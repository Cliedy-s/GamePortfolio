using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // unity functions
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    // Events
    private void OnEnable()
    {
        Debug.Log("MonsterOnEnable");
        this.Invoke("InvokeTest", 2f);
    }
    private void OnDisable()
    {
        Debug.Log("MonsterOnDisable");
    }

    // custom functions
    private void InvokeTest()
    {
        Debug.Log("invoke.InvokeTest");
    }

}
