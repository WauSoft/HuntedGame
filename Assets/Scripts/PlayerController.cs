using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Direction { Left, Right }

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float flipSpeed = 8;

    private GameObject sr;
    private Direction spriteOritentation = Direction.Right;
    private bool doneRotating = true;
    private Quaternion endRot;

	// Use this for initialization
	void Start ()
    {
        sr = gameObject.transform.GetChild(0).gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zDir = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        FlipSprite(xDir);
        transform.Translate(xDir, 0, zDir);
    }

    // graphics stuff
    void FixedUpdate()
    {
        if (!doneRotating)
        {
            sr.transform.localRotation = Quaternion.Lerp(sr.transform.localRotation, endRot, Time.fixedDeltaTime * flipSpeed);
            if (sr.transform.localRotation == endRot)
            {
                doneRotating = true;
            }
        }
        
    }

    private void FlipSprite(float xDir)
    {
        if (xDir != 0)
        {
            var sign = Mathf.Sign(xDir);

            if (sign > 0 && spriteOritentation != Direction.Right)
            {
                spriteOritentation = Direction.Right;
                doneRotating = false;
                endRot = Quaternion.Euler(Vector3.zero);
            }
            else if (sign < 0 && spriteOritentation != Direction.Left)
            {
                spriteOritentation = Direction.Left;
                doneRotating = false;
                endRot = Quaternion.Euler(new Vector3(0, 180));
            }
        }
    }
}