using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collision_Handler : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private AudioClip collisionAudio;
    [SerializeField] private AudioClip finishAudio;
    [SerializeField] private ParticleSystem finishEffect;
    [SerializeField] private ParticleSystem collisionEffect;
    [SerializeField] private AudioSource collisionSource;
    [SerializeField] private bool isTransitioning = false;
    [SerializeField] private bool collisionDisable = false;

    private void Update()
    {
        Debug_Keys();
    }

    private void Debug_Keys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextScene();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || collisionDisable)
        {
            return;
        }
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
        collisionEffect.Play();
        collisionSource.Stop();
        isTransitioning = true;
        collisionSource.PlayOneShot(collisionAudio); 
        ReloadLevel();
        Invoke("ReloadLevel", + waitTime); //invoke
        GetComponent<Movement>().enabled = false;
    }

    private void NextScene()
    {
        finishEffect.Play();
        collisionSource.Stop();
        isTransitioning = true;
        collisionSource.PlayOneShot(finishAudio);
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
