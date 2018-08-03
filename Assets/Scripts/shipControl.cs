﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipControl : MonoBehaviour 
{

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float RCSthurst = 100f;
    [SerializeField] float Mainthurst = 50f;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip leveUP;

    [SerializeField] ParticleSystem  ShipFlames;
	[SerializeField] ParticleSystem  ShipDestroy;
 

    enum States {Alive, Dying, Transcending }
    States State = States.Alive;



	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()

    {
        DebugKing();
        if(State == States.Alive)
        {
            Thurstmode();
            movementmode();
          
        }
    

    }

    void Thurstmode()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Mainthurst ); // add * delta.time
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                ShipFlames.Play();
            }
        }

        else
        {
            ShipFlames.Stop();
            audioSource.Stop();

        }
    }
     void movementmode()
    {
        float FrameperRotation = RCSthurst * Time.deltaTime;

        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.right * FrameperRotation);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.right * FrameperRotation);
        }


        rb.freezeRotation = false;

    }

     void OnCollisionEnter(Collision collision)

    {
        if(State!=States.Alive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            switch (collision.gameObject.tag)
            {
                case "Finish":
                    State = States.Transcending;
                    Invoke("LoadNextLevel", 1f);
                    audioSource.PlayOneShot(leveUP);
                    break;
                case "enemy":
                    State = States.Dying;
                    audioSource.Stop();
                    Invoke("LoadDeadLevel", 1f);
                    ShipDestroy.Play();
                    //ShipDestroy.Stop();
                    audioSource.PlayOneShot(death);
                    break;
                default:
                    print("nothing");
                    break;
            }
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    void LoadDeadLevel()
    {
        SceneManager.LoadScene(0);

    }

    void DebugKing()

    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(1);  // or loadNextlevel()
        }

    }

}


