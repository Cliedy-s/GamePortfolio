using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // [Singleton] - Ref Awake()
    public static GameManager instance;

    // 
    [Header("Camera Settings")]
    public Player player;
    public float mouseSensitive;
    public float cameraDefaultDistance = 3;
    public Vector3 cameraOffset;
    [Range(0, 1)]
    public float avoidDisPs;

    List<TrollGiant> monsters = new List<TrollGiant>();
    
    public Player Player { get => player; set => player = value; }
    public List<TrollGiant> Monsters { get => monsters; set => monsters = value; }

    // unity functions
    void Awake() {
        if(instance == null)
            instance = this;

        SoundManager.instance.LoadBGM();
        SoundManager.instance.LoadFx();
        // camera settings
        CustomCamera cam = Camera.main.gameObject.AddComponent<CustomCamera>();
        cam.MouseSensitive = mouseSensitive;
        cam.DefaultDistance = cameraDefaultDistance;
        cam.CameraOffset = cameraOffset;
        cam.Player = player.transform;
        cam.AvoidDisPs = avoidDisPs;
    }
    void Start()
    {
    }
    void Update()
    {
    }



}
