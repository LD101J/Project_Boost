using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variable
    private Rigidbody rb;
    [SerializeField] private float upThrusters;
    [SerializeField] private float rotateThrusters;
    [SerializeField] private AudioSource thrusterAudio;
    #endregion
    private void Start()
    {
       thrusterAudio = GetComponent<AudioSource>();
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
            if (!thrusterAudio.isPlaying)
            {
                thrusterAudio.Play();
            }
        }
        else
        {
            thrusterAudio.Pause();
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
