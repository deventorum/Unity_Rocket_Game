using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioData;
    AudioSource collisionAudio;
    [SerializeField] float MainThrust = 100f; 

    [SerializeField] float RcsThrust = 100f;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
        collisionAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
    }

    private void ProcessInput()
    {
        ThrustersEngaged();
        RotateRocket();
    }
    private void ThrustersEngaged()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * MainThrust);
            if (!audioData.isPlaying)
            {
                audioData.Play(0);
            }
        }
        else audioData.Pause();
    }

    private void RotateRocket()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation
        float rotationThisFrame = RcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidBody.freezeRotation = false;
    }
    // Blocks x and y rotation
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK"); //todo remove this line
                break;
            case "Fuel":
                print("Fuel");
                break;
            case "Finish":
                print("Congratulations!!!");
                break;
            default:
                print("Dead");
                // kill player
                break;
        }
    }

}
