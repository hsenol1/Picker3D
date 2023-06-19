using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificBallCounter : MonoBehaviour
{   
    public static int ballCount = 0;
    void Start() {
        ballCount = 0;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
             Debug.Log("Ball entered, setting ballsAreSettling to true");
            ballCount++;
            
          //  unityEvent.invoke();
        }
    }


    public static int GetBallCount() {
        return ballCount;
    }
}
