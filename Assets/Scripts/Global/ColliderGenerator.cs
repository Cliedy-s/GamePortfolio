using UnityEngine;

public class ColliderGenerator : MonoBehaviour
{
    //public SkinnedMeshRenderer meshFilter;
    void Start()
    {
        GetMinMaxVertexInfo();
    }
    void Update()
    {
        
    }

    // custom function
    void GetMinMaxVertexInfo(){
        // 1. Skinned Mesh Renderer의 메시정보에서 버텍스 접근
        SkinnedMeshRenderer renderer = GetComponent<SkinnedMeshRenderer>();
        if(renderer == null) // 자식 오브젝트 검색
            renderer = GetComponentInChildren<SkinnedMeshRenderer>();

        // 2. xyz의 최소값, 최대값 계산
        float xMin, xMax, yMin, yMax, zMin, zMax;
        xMin = xMax = renderer.sharedMesh.vertices[0].x;
        yMin = yMax = renderer.sharedMesh.vertices[0].y;
        zMin = zMax = renderer.sharedMesh.vertices[0].z;
        foreach (var item in renderer.sharedMesh.vertices)
        {
            if(item.x < xMin)
                xMin = item.x;
            if (item.x > xMax)
                xMax = item.x;
            if (item.y < yMin)
                yMin = item.y;
            if (item.y > yMax)
                yMax = item.y;
            if (item.z < zMin)
                zMin = item.z;
            if (item.z > zMax)
                zMax = item.z;
        }

        Debug.Log($"x: {xMin}, {xMax}");
        Debug.Log($"y: {yMin}, {yMax}");
        Debug.Log($"z: {zMin}, {zMax}");
        // 3. 콜라이더 박스 자동생성
         
        BoxCollider coll = GetComponent<BoxCollider>();
        if(coll == null) // 3-1 collider가 붙은 경우
            coll = gameObject.AddComponent<BoxCollider>();
        
        // coll.center = transform.position;
        coll.center = new Vector3(0, (zMax - zMin) * 0.5f, 0);
        coll.size = new Vector3(xMax - xMin, zMax - zMin, yMax - yMin);

        //Debug.Log(new Vector3((xMax - xMin) / 2, (yMax - yMin) / 2, (zMax - zMin) / 2));
        // coll.extents
        // 붙지 않은 경우
    }
}

