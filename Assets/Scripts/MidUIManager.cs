using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class MidUIManager : MonoBehaviour
{
    public GameObject midScreen;  // image
    public Button midButton;  // button 
    // Start is called before the first frame update
    void Start()
    {
        midScreen.SetActive(false);
        midButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlatformScript.getMidBoolVal()) {
            midScreen.SetActive(true);
            midButton.gameObject.SetActive(true);
            midButton.GetComponentInChildren<Text>().text = "Retry Level";
        

    
        }
    }
}
