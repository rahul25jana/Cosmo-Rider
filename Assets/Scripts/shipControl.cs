using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour 
{

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float RCSthurst = 100f;
    [SerializeField] float Mainthurst = 50f;


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
            rb.AddRelativeForce(Vector3.up * Mainthurst);
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
        switch (collision.gameObject.tag)
        {
            case "friendly":
                print("I'm Okay");
                break;
            default:
                print("nothing");
                break;
        }
    }


}
