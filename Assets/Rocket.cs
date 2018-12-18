using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioData;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
    }

    private void ProcessInput()
    {
        ThrustersEngaged();
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }

    private void ThrustersEngaged()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioData.isPlaying)
            {
                audioData.Play(0);
            }
        }
        else audioData.Stop();
    }
}
