using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : MonoBehaviour
{   
    public float forceMagnitude = 0.00000000001f;
    
    private void OnTriggerEnter(Collider other)
{   
   
    if (other.gameObject.CompareTag("Player"))
    {
        PlayerController.SetStopMovingTrue(); 
    }


    else if (other.gameObject.CompareTag("Ball"))
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forceMagnitude, ForceMode.Impulse);
    }
}

}
