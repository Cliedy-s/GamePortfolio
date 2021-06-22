using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class UIHP : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public float healthSetTime = 3;
    // unity functions
    private void Awake() {
        timesum = healthSetTime;
    }
    void Start()
    {
        SetHealth(100f, 80f, 100f);
    }
    void Update()
    {

    }
    // custom functions
    private void ResetHealth()
    {

    }
    private float timesum;
    public void SetHealth(float totalHealth, float nowHelath, float toHealth)
    {
        StartCoroutine(HealthUpdate(totalHealth, nowHelath, toHealth));
    }
    private IEnumerator HealthUpdate(float totalHealth, float nowHelath, float toHealth)
    {
        float min = toHealth;
        float max = toHealth;
        float amount;
        float tmpHealth = nowHelath;

        image.fillAmount = nowHelath / totalHealth;

        if (nowHelath > toHealth)
            max = Mathf.Infinity;
        else
            min = Mathf.NegativeInfinity;

        while (true)
        {
            amount = ((toHealth - nowHelath) / timesum) * Time.deltaTime;
            tmpHealth = Mathf.Clamp(tmpHealth += amount, min, max);
            image.fillAmount = tmpHealth / totalHealth;

            if (tmpHealth == toHealth)
                break;
            yield return null;
        }
    }
}
