using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    public float speed = 6;
    private bool levelStarted = false;
    private Vector3 targetPosition;
    private float targetX;
    private static bool stopMoving = false;
    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody>();    
    }

    void Start()
    {
        stopMoving = false;
    }

    public static void SetStopMovingTrue() {
        stopMoving = true;
       
    }




    public static void SetStopMovingFalse() {
        stopMoving = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !levelStarted) {
            levelStarted = true;
        }
     
        if (levelStarted && !stopMoving) {
           //  transform.Translate(0,0,0.04f);
            rb.MovePosition(rb.position + Vector3.forward * 0.1f);
            if (Input.GetMouseButton(0))
            {
                // Project mouse position onto player position plane
                Plane playerPlane = new Plane(Vector3.up, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (playerPlane.Raycast(ray, out float enter))
                {
                    targetX = ray.GetPoint(enter).x;

                    // Only consider horizontal movement
                    if (targetX < rb.position.x)
                    {
                        rb.velocity = Vector3.left * speed;
                    }
                    else if (targetX > rb.position.x)
                    {
                        rb.velocity = Vector3.right * speed;
                    }
                }
            }
            else
            {
                // Stop movement when mouse button is released
                rb.velocity = Vector3.zero;
            }
        }
        

        
      
    }
}