using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    public MeshRenderer render;
    Vector2 offset = new Vector2();
    public float scrollSpeed;

    void Start()
    {
        offset = render.material.GetTextureOffset("_MainTex");
    }
    void Update()
    {
        // transform.forward = Camera.main.transform.forward;
        offset.x = offset.x+Time.deltaTime * scrollSpeed;
        render.material.SetTextureOffset("_MainTex", offset);
    }
}
