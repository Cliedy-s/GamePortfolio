using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // [Singleton] - Ref Awake()
    public static GameManager instance;

    // 
    public Player player;
    List<Monster> monsters = new List<Monster>();
    
    public Player Player { get => player; set => player = value; }
    public List<Monster> Monsters { get => monsters; set => monsters = value; }

    // unity functions
    void Awake() {
        if(instance == null)
            instance = this;

        SoundManager.instance.LoadBGM();
        SoundManager.instance.LoadFx();
        CustomCamera cam = Camera.main.gameObject.AddComponent<CustomCamera>();
        cam.Player = player.transform;
    }
    void Start()
    {
    }
    void Update()
    {
    }



}
