using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardPlane : MonoBehaviour
{
    Transform camerat;
    void Start()
    {
        camerat = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(camerat, transform.up);
        transform.forward = Camera.main.transform.forward;
        if(Input.GetKeyDown(KeyCode.C))
            ChangeTexture("LowTrollPallet");
    }

    private void ChangeTexture(string name)
    {
        Debug.Log("TryChange");
        Texture2D tmp = Resources.Load<Texture2D>(name);
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", tmp);
    }

}
