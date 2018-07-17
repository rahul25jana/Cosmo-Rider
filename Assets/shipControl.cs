using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour {

    public GameObject Ship;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 

    {
		
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("rot left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("rot right");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("thurst");
        }
   
	}
}
