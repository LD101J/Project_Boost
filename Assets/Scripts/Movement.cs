using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float upThrusters;
    [SerializeField] private float rotateThrusters;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * upThrusters * Time.deltaTime); 
        }
    }
    private void ProcessRotation()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotateThrusters * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotateThrusters * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }
}
