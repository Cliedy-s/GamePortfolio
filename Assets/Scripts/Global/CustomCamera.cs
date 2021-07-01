using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    private Transform player;
    public Transform Player { get => player; set => player = value; }

    Vector3 playeroldpos = Vector3.zero;

    private float mouseSensitive;
    private float distance;
    private Vector3 cameraOffset;
    public float MouseSensitive { get => mouseSensitive; set => mouseSensitive = value; }
    public float DefaultDistance { get => distance; set => distance = value; }
    public Vector3 CameraOffset { get => cameraOffset; set => cameraOffset = value; }

    // 
    public float xmove = 0;
    public float ymove = 0;

    void Start()
    {
    }
    private void LateUpdate() {
        // // 캐릭터가 이동한 만큼 카메라 이동
        xmove += Input.GetAxis("Mouse X") * mouseSensitive;
        ymove -= Input.GetAxis("Mouse Y") * mouseSensitive;

        CameraRotation();
        CameraPosition();
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

}
