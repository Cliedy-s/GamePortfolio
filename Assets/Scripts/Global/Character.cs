using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Vector3 vEnd;
    public float moveSpeed;
    public float rotateSpeed;

    CustomCamera cam;

    int layermask;
    // unity functions
    void Start()
    {
        layermask = 1 << LayerMask.NameToLayer("Terrain");
        vEnd = transform.position;
        
        cam = Camera.main.gameObject.AddComponent<CustomCamera>();
        cam.Player = this.transform;
    }
    private void Awake() {

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity)){ 
                Debug.Log(hitInfo.collider.gameObject.name);
                if(hitInfo.collider.CompareTag("Terrain")){
                        vEnd = hitInfo.point;
                }
            }
        }
        MoveByTerrain();
        RotateCharacter();
    }

    // customfunctions
    void MoveByTerrain(){
        // 이동
        transform.position = Vector3.MoveTowards(transform.position, vEnd, Time.deltaTime*moveSpeed);

        // 높낮이 확인
        Vector3? newPos = GetYpos(transform.position, cLayer.Player);
        if(newPos.HasValue)
            transform.position = newPos.Value;
    }
    void RotateCharacter(){
        //회전
        Vector3 tmp = vEnd;
        tmp.y = transform.position.y;
        Vector3 dir = tmp - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * rotateSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    public Vector3? GetYpos(Vector3 pos, cLayer layer)
    {
        Vector3 raypos = pos;
        raypos.y += 50f;

        RaycastHit hitInfo;
        int layermask = 1 << (int)layer; ;
        layermask = ~layermask;


        Vector3 returnpos = pos;
        if (Physics.Raycast(raypos, -Vector3.up, out hitInfo, Mathf.Infinity, layermask))
        {
            returnpos.y = hitInfo.point.y;
            return returnpos;
        }
        return null;

    }
}

public enum cLayer { Player = 7, Monster = 8 }