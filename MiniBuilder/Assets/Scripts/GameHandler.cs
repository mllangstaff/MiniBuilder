using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void removeInstructions()
    {
        text.SetActive(false);
    }
}
