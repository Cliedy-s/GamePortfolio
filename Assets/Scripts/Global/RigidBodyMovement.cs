using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public Rigidbody rigid;

    [Header("Jump Ref")]
    public float jumpForce;
    public float jumpCount=2;

    float jcount;
    bool bJump = false;
    Vector3 m_Input;

    // unity functions
    private void Awake() {
        jcount = jumpCount;
    }
    void Start()
    {
    }
    void Update()
    {
        // 점프 (FLAG)
        if (Input.GetKeyDown(KeyCode.Space) && !bJump && jcount > 0)
        { 
            bJump = true;
        }
        // 이동 입력
        m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    private void FixedUpdate() {
        if(bJump){ // 점프
            bJump = false;
            jcount--;
            // force?
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // velocity?
            // rigid.velocity = Vector3.one * force;
            // location?
            // rigid.position = new Vector3(0, 2f, 0);
        }
        if (m_Input != Vector3.zero) // 이동
        {
            rigid.MovePosition(transform.position + m_Input * Time.deltaTime * jumpForce);
        }
        
    }
    // private void OnCollisionEnter(Collision other) {
    //     jcount = jumpCount;
    // }
    // custom functions
}
