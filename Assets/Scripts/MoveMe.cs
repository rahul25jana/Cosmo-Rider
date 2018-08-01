using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class MoveMe : MonoBehaviour 
{
    [SerializeField] Vector3 MoveVec = new Vector3(15f,15f,0) ;
  //  [Range(0, 1)] [SerializeField] float MovRange;
    [SerializeField] float Period = 2.5f;

    float MoveFac;

    Vector3 StartPos;
	// Use this for initialization
	void Start () 
    {
        StartPos = transform.position;

	}
	
	// Update is called once per frame15f
	void Update () 
    {
        float cycle = Time.time / Period;
        const float pii = Mathf.PI * 2f;
        float sinWave = Mathf.Sin(cycle * pii);

        MoveFac = sinWave / 2f + 0.5f;

        Vector3 offset = MoveFac * MoveVec;
        transform.position = StartPos + offset;
	}
}
