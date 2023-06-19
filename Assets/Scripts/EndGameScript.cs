using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public GameObject overlayScreen;
    // Start is called before the first frame update
    void Start()
    {
         overlayScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.GetEndScreenVal()) {
            overlayScreen.gameObject.SetActive(true);
        }
    }
}
