using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class MoveMe : MonoBehaviour 
{
    [SerializeField] Vector3 MoveVec;
    [Range(0, 1)] [SerializeField] float MovRange;

    Vector3 StartPos;
	// Use this for initialization
	void Start () 
    {
        StartPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 offset = MoveVec * MovRange;
        transform.position = StartPos + offset;
	}
}
