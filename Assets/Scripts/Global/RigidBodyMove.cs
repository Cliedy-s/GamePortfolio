using UnityEngine;

public class RigidBodyMove : MonoBehaviour
{
    public Rigidbody rigid;
    public float force;
    bool isjump=false;
    Vector3 m_Input;

    // unity functions
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isjump)
        {
            isjump = true;
        }
        m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate() {
        if(isjump){
            isjump = false;
            // force?
            rigid.AddForce(Vector3.up * force, ForceMode.Impulse);
            // velocity?
            // rigid.velocity = Vector3.one * force;
            // location?
            // rigid.position = new Vector3(0, 2f, 0);
        }
        if (m_Input != Vector3.zero)
        {
            rigid.MovePosition(transform.position + m_Input * Time.deltaTime * force);
        }
        
    }
    // custom functions
}
