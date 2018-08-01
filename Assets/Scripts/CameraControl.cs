using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    
    public GameObject PlayerShip;
    private Vector3 CamPos;
   // private Vector3 LockY;

	// Use this for initialization
	void Start () 
    {
        CamPos = transform.position - PlayerShip.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = PlayerShip.transform.position + CamPos;
        //Vector3 LockY = transform.position;
      //  LockY.z = PlayerShip.transform.position.z + CamPos.z;
        //LockY.z = PlayerShip.transform.position.z + CamPos.z;
       // transform.position = LockY;
	}
}
