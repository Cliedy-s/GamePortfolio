using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    public Image uici;
    Color origin = Color.white;
    public float speed=0.01f;
    public float showTime=3f;
    // unity functions
    void Start()
    {
        origin = uici.color;
        InvokeRepeating("FadeIn", 0, speed);
    }
    void Update()
    {
        
    }
    // custom functions
    void FadeIn(){
        Color tmp = uici.color;
        tmp.a += Time.deltaTime;
        uici.color = tmp;

        if(tmp.a >= 1f){
            StopRepeating("FadeIn");
            InvokeRepeating("FadeOut", showTime, speed);
        }

    }
    void StopRepeating(string methodn)
    {
        if(IsInvoking(methodn))
        {
            CancelInvoke(methodn);
        }
    }
    void FadeOut(){
        Color tmp = uici.color;
        tmp.a -= Time.deltaTime;
        uici.color = tmp;

        if (tmp.a >= 1f){
            StopRepeating("FadeOut");
            uici.color = origin;
        }
            

    }

}
