using UnityEngine;
using UnityEngine.AI;

public abstract class NavMonster : MonoBehaviour
{
    [Header("Etc")]
    public NavMeshAgent agent;
    public Player player;

    [Header("Settings")]
    public float minDis;
    public float maxDis;

    private Vector3 orgVect;
    private float monsterNum;                                            

    // unity functions
    void Awake(){
        orgVect = transform.position;
    }
    void Start(){
        RunStart();
    }
    void Update(){
        RunUpdate();
    }
    abstract public void RunAwake();
    abstract public void RunStart();
    abstract public void RunUpdate();

    // custom functions
    protected void DetectPlayer(){
        float dis = Vector3.Distance(player.transform.position, transform.position);

        // 거리에 따른 따라가기
        Vector3 minminVec = new Vector3(1, 1, 1);
        Vector3 targetDir = orgVect;

        if (dis <= minDis)
            targetDir = player.transform.position - minminVec;
        else if(dis >= maxDis)
            targetDir = orgVect;

        MoveByNav(targetDir);
    }
    protected void MoveByNav(Vector3 targetDir)
    {
        agent.destination = targetDir;
    }
    protected void GotHit(){}
    protected void Attack(Collision other){}
    protected void Die(){}
    // Events

}

