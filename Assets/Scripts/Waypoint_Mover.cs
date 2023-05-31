using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Mover : MonoBehaviour
{
    private Vector3 startingPos;
    [SerializeField] private Vector3 movementVector;
     private float movementFactor;
    [SerializeField] private float obstacleSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(obstacleSpeed <= Mathf.Epsilon)
        {
            return;
        }
        const float tau = Mathf.PI * 2;
        float cycles = Time.time / obstacleSpeed;
        float rawSinWave = Mathf.Sin(cycles * tau);
        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPos + offset;
        movementFactor = (rawSinWave + 1f) / 2f;
    }
}
