using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour 
{

    Rigidbody rb;
	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 

    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
      
   
	}
}
