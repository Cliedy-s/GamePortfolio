using System;
using TreeEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;

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

    protected Vector3 orgDir;
    // protected Vector3 beforeDir;
    protected float monsterNum;
    protected float playerDis;

    private bool isMoving = false;
    private bool isAttacked = false;
    private bool isHitDis = false;
    private bool isTryHit = false;
    private bool isDie = false;
    private int hp = 100;

    public  bool IsMoving { get => isMoving; set => isMoving = value; }
    public  bool IsAttacked { get => isAttacked; set => isAttacked = value; }
    public  bool IsHitDis { get => isHitDis; set => isHitDis = value; }
    public  bool IsTryHit { get => isTryHit; set => isTryHit = value; }
    public  bool IsDie    { get => isDie; set => isDie = value; }
    public  int Hp { 
        get {
            return hp;
        } 
        set {
            hp = value;
        } 
    }   

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
        // TODO -  트롤이 이상하게 움직임
        if(targetDir == transform.position)
            MovingPause();
        else Moving();
        SetDir(targetDir);
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
        Hp = Hp - hpPoint;
        if(Hp <= 0){
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
   // Events
    private   void OnCollisionEnter(Collision other) {
        Debug.Log("attaced...?");
        if(other.gameObject.tag == "Weapon"){
            Debug.Log("Attacked!");
        }
    }

}

