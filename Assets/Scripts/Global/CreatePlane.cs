using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    void Start()
    {
        Create(10, 10);  
    }
    void Update()
    {
        
    }
    // custom functions
    private GameObject Create(float width, float height)
    {
        // 1. 메시 생성
        Mesh m = new Mesh();
        m.name = "Plane_New_Mesh";

        // 2. 버텍스 정보 생성
        Vector3[] ver = new Vector3[4];
        ver[0].Set(-width * 0.5f, 0, 0);
        ver[1].Set(width * 0.5f, 0, 0);
        ver[2].Set(-width*0.5f , height, 0);
        ver[3].Set(width/2, height, 0);
        m.vertices = ver;
        // Array.Copy(ver, m.vertices, ver.Length);

        // 3. 폴리곤 정점 인덱스
        int[] tri = new int[6];
        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;
        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;
        m.triangles = tri;

        // 4. 정점 노멀
        Vector3[] normals = new Vector3[4];
        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;
        m.normals = normals;

        // 6. uv 좌표
        Vector2[] uv = new Vector2[4];
        uv[0].Set(0, 0);
        uv[1].Set(1, 0);
        uv[2].Set(0, 1);
        uv[3].Set(1, 1);
        m.uv = uv;

        GameObject obj= new GameObject("CreatePlane");
        obj.transform.SetParent(this.transform);
        MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
        MeshFilter mf = obj.AddComponent<MeshFilter>();
        mf.mesh = m;

        // 7. Material
        Material mat = new Material(Shader.Find("Standard"));
        renderer.material = mat;

        return obj;
    }
    private void ChangeTexture(string name)
    {
        Texture2D tmp = Resources.Load<Texture2D>(name);
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", tmp);
    }

}
