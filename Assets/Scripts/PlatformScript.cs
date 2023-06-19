using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int ballCount = 0;
    private float transitionTime = 1.0f;
     private Vector3 targetPosition = new Vector3(0.05f, -0.09f, 60.79f);
     private static bool openScreen = false;

    void Start () {
        openScreen = false;
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the object leaving the trigger is a ball
         if (other.gameObject.CompareTag("Ball"))
        {
            ballCount++;
             StartCoroutine(DecideAfterDelay(3f));
            // Check if more than 3 balls have fallen from the platform
           
        }
    }


    IEnumerator DecideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (ballCount > 3)
        {
           
            StartCoroutine(TransitionToTarget());
        }
        else
        {
            openScreen = true;
        }
    }


    IEnumerator TransitionToTarget()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < transitionTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Make sure the position is exactly the target position at the end
        transform.position = targetPosition;
        UIManager.SetCountingBallsFalse();
        PlayerController.SetStopMovingFalse();
    }


    public static bool getMidBoolVal() {
        return openScreen;
    }

    public static void setMidBoolTrue() {
        openScreen = true;
    }
}
