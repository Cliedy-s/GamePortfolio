using System;
using TreeEditor;
using UnityEngine;
using UnityEngine.AI;

public abstract class NavMonster : MonoBehaviour
{
    [Header("Etc")]
    public NavMeshAgent agent;
    public Player player;

    [Header("Settings")]
    public float minDis = 5f;
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
    private bool isHit;
    private bool isHitDis;
    private bool isTryHit;
    private bool isDie = false;

    public  bool IsMoving { get => isMoving; set => isMoving = value; }
    public  bool IsHit    { get => isHit; set => isHit = value; }
    public  bool IsHitDis { get => isHitDis; set => isHitDis = value; }
    public  bool IsTryHit { get => isTryHit; set => isTryHit = value; }
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
        RunUpdate();
    }
    abstract public void RunAwake();
    abstract public void RunStart();
    abstract public void RunUpdate();

    // custom functions
    public void DetectPlayer(){ // 선제공격 따라가기
        // 거리에 따른 따라가기
        Vector3 minminVec = new Vector3(1, 1, 1);
        Vector3 targetDir = orgDir;

        if (playerDis <= minDis)
            targetDir = player.transform.position - minminVec;
        else if (playerDis >= maxDis)
            targetDir = orgDir;

        MoveByNav(targetDir);
    }
    private   void MoveByNav(Vector3 targetDir){
        agent.destination = targetDir;
    }
    protected void MovingPause(){
        // beforeDir = agent.destination;
        agent.isStopped = true;
        IsMoving = false;
    }
    protected void MovingResume(){
        agent.isStopped = false;
        IsMoving = true;
    }
    protected void GotHit(){
        IsHit = true;
        MovingPause();
        if(hp <= 0){
            Invoke("Die", hitTime);
            IsDie = true;
            return;
        }
        Invoke("GotHitRecover", hitTime);
    }
    private   void GotHitRecover(){
        IsHit = false;
        MovingResume();
    }
    protected void TryAttack(){
        isHitDis = false;
        if (playerDis <= hitDis){
            isHitDis = true;
        }
    }
    public    void OnAttack(Collider other){
        if(other.gameObject.tag == "Monster")
            Debug.Log($"Attack : {other.gameObject.name}");
    }
    protected void Die(){
        IsDie = true;
    }
    protected void AttackWhenClose()
    {

    }
    // Events

}

