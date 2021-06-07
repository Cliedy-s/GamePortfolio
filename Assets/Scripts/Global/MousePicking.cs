using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicking : MonoBehaviour
{
    Vector3 vEnd;
    public float moveSpeed;
    public float rotateSpeed;

    int layermask;
    // Start is called before the first frame update
    void Start()
    {
        layermask = 1 << LayerMask.NameToLayer("Terrain");
        vEnd = transform.position;
    }
    private void Awake() {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라 기준 광선 생성
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity)){ // 성능에 영향 ㅇ, 모니터 안쪽으로 광선 발싸! => hitinfo 저장
                //if(hitInfo.collider.tag == "Terrain"){
                if(hitInfo.collider.CompareTag("Terrain")){ // 메모리가 더 적게 들어감
                        vEnd = hitInfo.point;
                }
            }
            // 충돌한 게임오브젝트의 트렌스폼
            // hitInfo.collider.transform
            // 게임 오브젝트
            // hitInfo.collider.gameObject
            // 충돌한 오브젝트의 컴포넌트
            // hitInfo.collider.gameObject.GetComponent<MeshRenderer>();

        }

        MoveByTerrain();
    }

    void MoveByTerrain(){
        // 이동
        transform.position = Vector3.MoveTowards(transform.position, vEnd, Time.deltaTime*moveSpeed);
        Vector3? newPos = GameHelper.GetYpos(transform.position, eLayer.Player);

        if(newPos.HasValue)
            transform.position = newPos.Value;
        else
            Debug.LogError("캐릭터가 공중에 있음");
        // Vector3 tmp = transform.position;

        // // 이동 코드
        // RaycastHit hitInfo;
        // Vector3 tmpdir = Vector3.MoveTowards(transform.position, vEnd, Time.deltaTime* moveSpeed);
        // // 굴곡진 지형 - raycast
        // Physics.Raycast(transform.position + new Vector3(0,10,0), Vector3.down, out hitInfo, 20f, layermask);
        // Vector3 movenewdir = new Vector3(tmpdir.x, hitInfo.point.y, tmpdir.z);
        // transform.position = movenewdir;

        //회전
        Vector3 tmp = vEnd;
        tmp.y = transform.position.y;
        Vector3 dir = tmp - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * rotateSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDir);
        // Vector3 rotateVector = Vector3.RotateTowards(transform.forward, vEnd, Time.deltaTime*rotateSpeed, 0.0f);
        // //Vector3 newDir = new Vector3(rotateVector.x, transform.position.y, rotateVector.z);
        // transform.rotation = Quaternion.LookRotation(rotateVector);
    }
}
