using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private float SpeedOffset
    {
        get { return Time.deltaTime * 5; }
    }

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal") * SpeedOffset;
        float zDir = Input.GetAxis("Vertical") * SpeedOffset;
        transform.Translate(xDir, 0, zDir);
    }
}