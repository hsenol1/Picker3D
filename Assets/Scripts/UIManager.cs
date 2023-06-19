using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class UIManager : MonoBehaviour
{
    public GameObject overlayScreen;  // image
    public Button levelButton;  // button 
    private static bool isCountingBalls = false;
    private static int ballCount;
    private int ballLimit;
    private bool overlayShown = false;
    public static UIManager Instance;
    private static bool openEndScreen = false;
    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != null) {
            Destroy(gameObject);
        }

        
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            ballLimit = 4;
        }
        
        else if (SceneManager.GetActiveScene().name == "Level2") 
        {
            ballLimit = 6;
        }
        else 
        {
            ballLimit = 6;
        }

    
    }

    public void ResetState() {
        overlayShown = false;
        isCountingBalls = false;
        
    }
    

    void Start() {
        ResetState();
        overlayScreen.gameObject.SetActive(false);
        levelButton.gameObject.SetActive(false);
        overlayShown = false;
        isCountingBalls = false;
        openEndScreen = false;
        ResetBallCount();


    }


    
    void Update()
    {
        
        
        if (!isCountingBalls && BallCounter.GetBallCount() > 0)
        {
            isCountingBalls = true;
            
        }

        if (isCountingBalls)
        {
            ballCount = BallCounter.GetBallCount();
        }

        if (isCountingBalls && !BallCounter.BallsAreSettling() && !overlayShown)
        {
            StartCoroutine(ShowOverlayAfterDelay(3f));
        }
        
    }

    IEnumerator ShowOverlayAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        overlayScreen.SetActive(true);
        levelButton.gameObject.SetActive(true);
        
        if (ballCount >= ballLimit)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "Level2") {
                levelButton.GetComponentInChildren<Text>().text = "";
                openEndScreen = true;
            }
            else {
                levelButton.GetComponentInChildren<Text>().text = "Next Level";
            }

            
          
        }
        else
        {
            levelButton.GetComponentInChildren<Text>().text = "Retry Level";
        }

        overlayShown = true;
    }

    public static void ResetBallCount() {
        ballCount = 0;
    }
    public void HideLevelButton()
    {
        levelButton.gameObject.SetActive(false);
    }

    public static void SetCountingBallsFalse() {
        isCountingBalls = false;
    }


    public static bool GetEndScreenVal() {
        return openEndScreen;
    }
   

  
}
