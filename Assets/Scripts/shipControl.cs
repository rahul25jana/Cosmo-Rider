using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour 
{

    Rigidbody rb;
    AudioSource audioSource;
	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()

    {
        Thurstmode();
        movementmode();

    }

    void Thurstmode()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        else
        {
            audioSource.Stop();

        }
    }
     void movementmode()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.right);
        }
        rb.freezeRotation = false;

    }


}
