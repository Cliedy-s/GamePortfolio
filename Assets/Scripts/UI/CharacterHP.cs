using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// following HP
/// </summary>
public class CharacterHP : MonoBehaviour
{
    public Image hp;
    public Transform hpPos;
    public float activeDistance = 100f;
    // unity functions
    void Start()
    {
        setHpbarLocation();
    }
    void Update()
    {
        setHpbarLocation();
        setActive();
    }
    // custom functions
    /// <summary>
    /// 캐릭터 좌표 => 화면
    /// </summary>
    public void setHpbarLocation(){ // 캐릭터 좌표 => 화면
        hp.transform.position = Camera.main.WorldToScreenPoint(hpPos.transform.position);
    }
    private void setActive()
    {
        if(Vector3.SqrMagnitude(Camera.main.transform.position - transform.position) > activeDistance)
            hp.gameObject.SetActive(false);
        else 
            hp.gameObject.SetActive(true);
    }

}
