using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetMeshInfo();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // custom function
    void GetMeshInfo(){
        MeshFilter mf = GetComponent<MeshFilter>();

        // Debug.Log($"정점의 개수 : {mf.mesh.vertexCount}");
        // foreach (var item in mf.mesh.vertices)
        // {
        //     Debug.Log($"지역 좌표 : {item}");
        //     Vector3 worldPos = Vector3.zero; //transform.position + item;
        //     worldPos.x = transform.position.x + item.x * transform.localScale.x;
        //     worldPos.y = transform.position.y + item.y * transform.localScale.y;
        //     worldPos.z = transform.position.z + item.z * transform.localScale.z;

        //     Debug.Log($"월드 좌표 : {worldPos}");

        //     GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //     tmp.transform.position = worldPos;
        // }

        // foreach (var item in mf.mesh.triangles)
        // {
        //     Debug.Log(item);
        // }

        // Debug.Log($"노멀의 개수 : {mf.mesh.normals.Length}");
        // foreach (var item in mf.mesh.normals)
        // {
        //     Debug.Log(item);
        // }
    }
}
