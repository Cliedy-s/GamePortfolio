using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // unity functions
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        // Debug.Log($"OnCollisionEnter: {other.collider.name}");
    }
    private void OnCollisionStay(Collision other) {
        // Debug.Log($"OnCollisionStay: {other.collider.name}");
    }
    private void OnCollisionExit(Collision other) {
        // Debug.Log($"OnCollisionExit: {other.collider.name}");
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"{this.name} triggered? {other.name}");
    }
    private void OnTriggerStay(Collider other) {
        
    }
    private void OnTriggerExit(Collider other) {
        
    }
}
