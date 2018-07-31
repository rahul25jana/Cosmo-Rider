using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    
    public GameObject PlayerShip;
    private Vector3 CamPos;

	// Use this for initialization
	void Start () 
    {
        CamPos = transform.position - PlayerShip.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = PlayerShip.transform.position + CamPos;
        //this.transform.position = PlayerShip.transform.position + new Vector3(CamPos.x, CamPos.y, 0);
	}
}
