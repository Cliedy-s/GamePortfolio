using System;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;
using UnityEngine.SubsystemsImplementation;

public abstract class NavMonster : MonoBehaviour
{
    [Header("Etc")]
    public NavMeshAgent agent;
    public Player player;

    [Header("Settings")]
    public float minDis = 1f;
    public float maxDis = 10f;
    [Space(3f)]
    public float hitTime = 0.2f;
    public float hitDis = 1f;
    [Space(3f)]
    public int totalHp = 100;
    public int hp = 100;

    protected Vector3 orgDir;
    // protected Vector3 beforeDir;
    protected float monsterNum;
    protected float playerDis;

    private bool isMoving = false;
    private bool isAttacked = false;
    private bool isHitDis = false;
    private bool isTryHit = false;
    private bool isDie = false;

    public  bool IsMoving { get => isMoving; set => isMoving = value; }
    public  bool IsAttacked { get => isAttacked; set => isAttacked = value; }
    public  bool IsHitDis { get => isHitDis; set => isHitDis = value; } // 공격한다
    public  bool IsTryHit { get => isTryHit; set => isTryHit = value; } // 공격중인가?
    public  bool IsDie    { get => isDie; set => isDie = value; }

    // unity functions
    void Awake(){
        orgDir = transform.position;
        playerDis = Vector3.Distance(player.transform.position, transform.position);
        RunAwake();
    }
    void Start(){
        RunStart();
    }
    void Update(){
        playerDis = Vector3.Distance(player.transform.position, transform.position);
        DetectSpeed();
        TryAttackWhenClose();

        RunUpdate();
    }
    abstract public void RunAwake();
    abstract public void RunStart();
    abstract public void RunUpdate();

    // custom functions
    public    void DetectPlayer(){
        // 거리에 따른 따라가기
        Vector3 targetDir = orgDir;
        if(playerDis <= minDis){ // 공격범위
            targetDir = transform.position;
        }
        else if (playerDis >= maxDis) { // 너무 멈 
            targetDir = orgDir;
        }
        else if(playerDis <= maxDis){ // 따라가기
            targetDir = player.transform.position;
        }
        SetDir(targetDir);
    }
    private   void DetectSpeed(){
        if(agent.velocity == Vector3.zero)
            IsMoving = false;
        else
            IsMoving = true;
    }
    public    void SetRotate(){
        Quaternion _qua = Quaternion.LookRotation(player.transform.position - transform.position);
        Vector3 _euler = _qua.eulerAngles;
        _euler.x = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_euler), 10f * Time.deltaTime);
    }
    private   void SetDir(Vector3 targetDir){
        agent.destination = targetDir;
    }
    protected void MovingPause(){
        IsMoving = false;
    }
    protected void Moving(){
        IsMoving = true;
    }
    protected void GotHit(int hpPoint){
        IsAttacked = true;
        MovingPause();
        hp = hp - hpPoint;
        if(hp <= 0){
            Invoke("Die", hitTime);
            IsDie = true;
            return;
        }
        Invoke("GotHitRecover", hitTime);
    }
    private   void GotHitRecover(){
        IsAttacked = false;
        Moving();
    }
    protected void TryAttackWhenClose(){
        isHitDis = false;
        if (playerDis <= hitDis){
            isHitDis = true;
        }
    }
    public    void OnAttack(Collider other){
        if(other.gameObject.tag == "Monster")
            Debug.Log($"Attack : {other.gameObject.name}");
    }
    public    void OnAttacked(Collider other){

    }
    protected void Die(){
        IsDie = true;
    }


}

