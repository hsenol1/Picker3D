using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    public static int ballCount = 0;
    private static bool ballsAreSettling = false;
    private const float BALL_SETTLED_COOLDOWN = 1f;
    // public UnityEvent unityEvent;
    void Start() {
        ResetBallCount();
    }

    void Update() {
        if (ballsAreSettling)
        {
            Invoke("ResetBallsAreSettlingFlag", BALL_SETTLED_COOLDOWN);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
        
            ballCount++;
            ballsAreSettling = true;
          //  unityEvent.invoke();
        }
    }

     private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.CompareTag("Ball"))
         {
            Debug.Log("Ball exited, setting ballsAreSettling to true");
            ballCount--;
             ballsAreSettling = true;
            
         }
     }

    
    public void ResetBallsAreSettlingFlag()
    {
        ballsAreSettling = false;
    }

    public static int GetBallCount() {
        return ballCount;   
    }

    public static bool BallsAreSettling()
    {
        return ballsAreSettling;
    }

    public static void ResetBallCount() {
        ballCount = 0;
    }
}