using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformString : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.TextMesh BallCountText; 

    // Update is called once per frame
    void Update()
    {
        BallCountText.text = "Ball Count: " + SpecificBallCounter.GetBallCount().ToString() + "/" + "6";  // update text
    }
}
