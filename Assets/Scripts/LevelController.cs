using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LevelController : MonoBehaviour
{
    public Button levelButton; 
 

    
    
    void Start()    
    {
        levelButton.onClick.AddListener(OnButtonClick);
        
    }

    // Update is called once per frame
    void OnButtonClick()
    {
        Text buttonText = levelButton.GetComponentInChildren<Text>();

        if(buttonText.text == "Retry Level") {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
       
        }

        else if (buttonText.text == "Next Level") {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level2");
            

        }

        else if (buttonText.text == "Click to Quit!") {
            Application.Quit();
        }

        BallCounter.ResetBallCount();


         UIManager.Instance.ResetState();


        
        
    }
}
