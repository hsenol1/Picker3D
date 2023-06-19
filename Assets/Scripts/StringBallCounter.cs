using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class StringBallCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.TextMesh BallCountText; 

    // Update is called once per frame
    void Update()
    {
        Scene currentScene= SceneManager.GetActiveScene();

        if (currentScene.name == "Level2") {
            BallCountText.text = "Ball Count: " + BallCounter.GetBallCount().ToString() + "/" + "6"; 
        }

        else if (currentScene.name == "Level1") {
            BallCountText.text = "Ball Count: " + BallCounter.GetBallCount().ToString() + "/" + "4";
        }

        
    }
}
