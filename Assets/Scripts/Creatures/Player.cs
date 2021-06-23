using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Vector3 vEnd;
    [Header("Rigidbody")]
    public Rigidbody playerRigid;
    [Header("Speeds")]
    public float moveSpeed;
    public float jumpPower;
    public float rotateSpeed;
    public float minRotationSpeed;

    private float v = 0f;
    private float h = 0f;
    public float hp = 100f;
    private bool defence = false;
    private bool attack = false;
    private bool isTryJump = false;
    private bool isTryRoll = false;
    private bool isGround = false;
    private Vector3 camF, camR;

    public float V { get => v; }
    public float H { get => h; }
    public bool Defence { get => defence; }
    public bool Attack { get => attack; }
    public bool IsTryJump {get => isTryJump; set => isTryJump = value; }
    public bool IsTryRoll { get => isTryRoll; set => isTryRoll = value; }
    public bool ISDEAD { get { if (hp <= 0) return true; return false; } }

    int layermask;

    // unity functions
    void Start()
    {
        layermask = 1 << LayerMask.NameToLayer("Terrain");
        // vEnd = transform.position;
    }
    void Awake(){
        // CustomCamera script = Camera.main.gameObject.AddComponent<CustomCamera>();
        // script.Player = transform;
    }
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        defence = Input.GetMouseButton(1);
        attack = Input.GetMouseButton(0);
        isTryJump = false;
        if(Input.GetButton("Jump")){ // jump
            isTryJump = true;
        }
        isTryRoll = false;
        if (Input.GetButton("Avoid")){ // avoid
            isTryRoll = true;
        }
    }
    
    // custom functions
    public void Move(){ // TODO - 점프하면 움직이는거 가능하게 하기!!
        // 카메라가 바라보는 방향 => 앞
        Transform cameraTransform = Camera.main.transform;
        camF = cameraTransform.forward.normalized;
        camR = cameraTransform.right.normalized;
        Vector3 newcamF = new Vector3(camF.x, 0, camF.z);
        Vector3 newcamR = new Vector3(camR.x, 0, camR.z);
        Vector3 targetDirection = newcamR * H + newcamF * V;

        if (V != 0 || H != 0)
        {
            playerRigid.MovePosition(transform.position + (targetDirection * Time.deltaTime * moveSpeed));
            // Debug.Log(targetDirection);
            // playerRigid.AddForce();
            // transform.position = transform.position + (targetDirection* moveSpeed * Time.deltaTime);
        }
    }
    public void StickToTerrain(){
        // TODO - 캐릭터 Y축 설정, 옛날 버전이라 바꿔야 한다함
        // y축 교정
        Vector3? newPos = GameHelper.GetYpos(transform.position, eLayer.Player);

        if (newPos.HasValue)
            transform.position = newPos.Value;
    }
    public void Turn() { // function - 카메라 기준 Player 회전
        if (Mathf.Abs(H) <= minRotationSpeed && Mathf.Abs(V) <= minRotationSpeed)
            return;

        Transform cameraTransform = Camera.main.transform;

        camF = cameraTransform.forward.normalized;
        camR = cameraTransform.right.normalized;

        Vector3 newcamF = new Vector3(camF.x, 0, camF.z);
        Vector3 newcamR = new Vector3(camR.x, 0, camR.z);

        Vector3 targetDirection = newcamR * H + newcamF * V;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotateSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    public void TryJump(){
        if(isGround){
            // Debug.Log((transform.up) * jumpPower * Time.deltaTime);
            playerRigid.AddForce((transform.up) * jumpPower * Time.deltaTime, ForceMode.Impulse);
        }
    }
    void WalkForwardStep() { // function - per walk step
        // TODO - FUNCTION 이벤트 위치 조정이 필요함
        // Debug.Log("WalkForwardStep");
    }

    // events
    private void OnCollisionStay(Collision other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            isGround = false;
        }
    }
}
