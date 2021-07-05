using System.Collections;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // Vector3 vEnd;
    [Header("Etc")]
    public Animator animator;
    public Rigidbody playerRigid;
    public DogAttack attackScript;
    public NavMeshAgent agent;
    [Header("Speeds")]
    public float moveSpeed;
    public float jumpPower;
    public float dodgePower;
    public float dodgeAmount;
    public float rotateSpeed;
    public float minRotationSpeed;

    private float v = 0f;
    private float h = 0f;
    public  float hp = 100f;
    private bool defence = false;
    private bool attack = false;
    private bool isTryJump = false;
    private bool isTryDodge = false;
    private bool isGround = true;
    private Vector3 camF, camR;
    private IEnumerator dodgeCoroutine;

    public float V { get => v; }
    public float H { get => h; }
    public bool Defence { get => defence; }
    public bool Attack { get => attack; }
    public bool IsTryJump {get => isTryJump; set => isTryJump = value; }
    public bool IsTryDodge { get => isTryDodge; set => isTryDodge = value; }
    public bool ISDEAD { get { if (hp <= 0) return true; return false; } }

    int layermask;

    // unity functions
    void Start()
    {
        layermask = 1 << LayerMask.NameToLayer("Terrain");
    }
    void Awake(){
        agent.speed = moveSpeed;
    }
    void Update()
    {
        PCInput();
    }
    
    // custom functions
    public void PCInput(){
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        defence = Input.GetMouseButton(1);
        attack = Input.GetMouseButton(0);
        isTryJump = false;
        isTryDodge = false;
        if(isGround){
            if (Input.GetButton("Jump"))
            { // jump
                isTryJump = true;
            }
            if (Input.GetButton("Avoid"))
            { // avoid
                isTryDodge = true;
            }
        }
    }
    
    public void Move(){
        Vector3 targetDirection = CameraFromDirection(); 
        if (V != 0 || H != 0)
        {
            // Debug.Log(targetDirection * moveSpeed);
            agent.destination = transform.position + targetDirection;
            // playerRigid.MovePosition(transform.position + (targetDirection * Time.deltaTime * moveSpeed));
        }
    }
    public void Turn() { // function - 카메라 기준 Player 회전
        if (Mathf.Abs(H) <= minRotationSpeed && Mathf.Abs(V) <= minRotationSpeed)
            return;

        Vector3 targetDirection = CameraFromDirection();
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotateSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    public void TryJump(){// function -  캐릭터 jump
        isGround = false;
        playerRigid.AddForce(transform.up * jumpPower, ForceMode.Impulse);
    }
    public void TryDodge(){// function - 캐릭터 dodge ,StopPlayerCoroutine로 종료 - 애니메이션Exit에서 호출
        Vector3 dir = CameraFromDirection();
        Vector3 newdir = dir == Vector3.zero ? transform.forward : dir;
        transform.rotation = Quaternion.LookRotation(dir);

        dodgeCoroutine = PlayerDodge();
        StartCoroutine(dodgeCoroutine);
    }
    public void SetAttack(bool isAttack){
        attackScript.IsAttacking = isAttack;
    }
    public Vector3 CameraFromDirection(){ // 메인카메라 기준 Input 방향조정
        Transform cameraTransform = Camera.main.transform;
        camF = cameraTransform.forward.normalized;
        camR = cameraTransform.right.normalized;
        Vector3 newcamF = new Vector3(camF.x, 0, camF.z);
        Vector3 newcamR = new Vector3(camR.x, 0, camR.z);

        Vector3 clamped = Vector3.ClampMagnitude(newcamR * H + newcamF * V, 1f);
        return clamped;
    }
    public void StopPlayerCoroutine(Coroutines coroutine){
        if (coroutine == Coroutines.Dodge) StopCoroutine(dodgeCoroutine);
    }
    private IEnumerator PlayerDodge(){ // function - addforce하면 rigidbody 중력때문에 방향이 자꾸 변경되어 추가
        while (true)
        {
            agent.destination = transform.position + (transform.forward * dodgeAmount);
            // playerRigid.MovePosition(transform.position + (transform.forward * dodgePower * Time.deltaTime));
            yield return null;
        }
    }
    private void WalkForwardStep(){ // function - per walk step
        // TODO - FUNCTION 이벤트 위치 조정이 필요함
        // Debug.Log("WalkForwardStep");
    }
    
    // events
    private void OnCollisionEnter(Collision other) {
        if (other.collider != null && other.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            if (!isGround)
            {
                isGround = true;
            }
        }
    }
    public void OnAttack(Collider other){ // call by waepon OnTriggerEnter
        if(other.gameObject.tag == "Monster"){
            
        }
    }
}

public enum Coroutines { Dodge }
