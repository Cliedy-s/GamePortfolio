using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundObject : MonoBehaviour
{
    Bounds bounds;
    public Bounds BOUNDS { get => bounds; }
    public BoundObject other = null;


    // unity functions
    void Start()
    {
        bounds.center = transform.position;
        bounds.extents = new Vector3(0.5f, 0.5f, 0.5f);
    }
    void Update()
    {
        if(other != null){
            bounds.center = transform.position;
            if (bounds.Intersects(other.BOUNDS))
                Debug.Log($"충돌한 오브젝트 : {other.name}");
        }

    }
    // custom functions
}
