using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    private Transform player;
    public Transform Player { get => player; set => player = value; }
    Vector3 playeroldpos = Vector3.zero;
    const float zdelta = -11.020f;
    const float ydelta = 2.32f;
    const float xdelta = -51.09f;
    const float xangle = 10f;

    void Start()
    {
        playeroldpos = player.position;

        //카메라 기본 위치
        Vector3 campos = player.position;
        campos.z += zdelta;
        campos.y += ydelta;
        transform.position = campos;

        Vector3 angle = Vector3.zero;
        angle.x = xangle;
        transform.localEulerAngles = angle;
    }
    private void LateUpdate() {
        // 캐릭터가 이동한 만큼 카메라 이동
        Vector3 delta = player.position - playeroldpos;
        transform.position += delta;

        playeroldpos = player.position;
    }
}
