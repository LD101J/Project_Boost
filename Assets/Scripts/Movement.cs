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
    [SerializeField] private AudioClip mainEngine;
    [SerializeField] private ParticleSystem mainBooster;
    [SerializeField] private ParticleSystem rightBooster;
    [SerializeField] private ParticleSystem leftBooster;
    #endregion
    private void Start()
    {
       thrusterAudio = GetComponent<AudioSource>();
       rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Process_Thrust();
        Process_Rotation();
    }
    private void Process_Thrust()
    {
        Start_Thrust();
    }

    private void Start_Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            mainBooster.Play();
            rb.AddRelativeForce(Vector3.up * upThrusters * Time.deltaTime);
            if (!thrusterAudio.isPlaying)
            {
                thrusterAudio.PlayOneShot(mainEngine);
            }
        }
        else
        {
            thrusterAudio.Pause();
            mainBooster.Pause();


        }
    }

    private void Process_Rotation()
    {
        Steer_Rocket();
    }

    private void Steer_Rocket()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftBooster.Play();
            rightBooster.Pause();
            transform.Rotate(Vector3.forward * rotateThrusters * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rightBooster.Play();
            leftBooster.Pause();
            transform.Rotate(-Vector3.forward * rotateThrusters * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }
}
