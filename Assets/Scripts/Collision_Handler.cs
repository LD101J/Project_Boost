using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collision_Handler : MonoBehaviour
{
    [SerializeField] private float waitTime;
      
     
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("friend");
                break;
            case "Finished":
                NextScene();
                break;
            case "Fuel":
                Debug.Log("fueled");
                break;
            case "Obstacle":
                CrashSequence();
                break;
        }
        
    }

    private void CrashSequence()
    {
        ReloadLevel();
        Invoke("ReloadLevel", + waitTime); //invoke
        GetComponent<Movement>().enabled = false;
    }

    private void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentScene + 1;
        SceneManager.LoadScene(1);
        GetComponent<Movement>().enabled = false;
        Invoke("NextScene", + waitTime); //invoke
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentScene);
    }
}
