using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    private float avoidDisPs;
    private Transform player;
    public Transform Player { get => player; set => player = value; }

    Vector3 playeroldpos = Vector3.zero;

    private float avoidDis;
    private List<string> avoidTags = new List<string>();
    private float mouseSensitive;
    private float distance;
    private Vector3 cameraOffset;
    public float MouseSensitive { get => mouseSensitive; set => mouseSensitive = value; }
    public float DefaultDistance { get => distance; set => distance = value; }
    public Vector3 CameraOffset { get => cameraOffset; set => cameraOffset = value; }
    public float AvoidDisPs { get => avoidDisPs; set => avoidDisPs = value; }

    // 
    public float xmove = 0;
    public float ymove = 0;

    void Start()
    {
        avoidTags.Add("Player");
        avoidTags.Add("Weapon");
        avoidTags.Add("MonsterWeapon");
    }
    private void LateUpdate() {
        // 카메라 충돌 거리 ( 카메라 ~ 플레이어, 카메라 기준 )
        avoidDis = Vector3.Distance(player.transform.position, transform.position) * (1 - AvoidDisPs);

        // 캐릭터가 이동한 만큼 카메라 이동
        xmove += Input.GetAxis("Mouse X") * mouseSensitive;
        ymove -= Input.GetAxis("Mouse Y") * mouseSensitive;

        CameraRotation();
        CameraPosition();
        AvoidObject();
    }

    private void CameraPosition()
    {
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        transform.position = (player.transform.position - transform.rotation * reverseDistance) + cameraOffset;
    }
    private void CameraRotation()
    {
        transform.rotation = Quaternion.Euler(ymove, xmove, 0);
    }
    private void AvoidObject(){
        Vector3 dir = transform.position - player.transform.position;
        RaycastHit[] hitinfos = 
            Physics.RaycastAll(
                player.transform.position
                , dir.normalized
                , Vector3.Distance(player.transform.position, transform.position));
        
        foreach (RaycastHit item in hitinfos)
        {
            if(Vector3.Distance(player.transform.position, item.point) <= avoidDis)
                continue;
            if(avoidTags.Contains(item.collider.tag))
                continue;
            
            transform.position = item.point;
        }
    }

}
