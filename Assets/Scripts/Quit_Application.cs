using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Application : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pussy, is the game too hard");
            Application.Quit();
        }
    }
}
