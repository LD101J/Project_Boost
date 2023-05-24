using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Handler : MonoBehaviour
{
      
     
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("friend");
                break;
            case "Finished":
                Debug.Log("finito");
                break;
            case "Fuel":
                Debug.Log("fueled");
                break;
            case "Obstacle":
                Debug.Log("obstacle");
                break;
        }
        
    }

    
}
