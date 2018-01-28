﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public float Size { get; set; }
    public float Speed { get; set; }
    public int Id { get; set; }
    private Animator animator;

    private float boundX, boundZ;
    private void Start()
    {
        animator = GetComponent<Animator>();
        boundX = 4f;
        boundZ = 4f;
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Bounce");
    }

    public void MovePlatform(KeyCode keyLeft, KeyCode keyRight)
    {
        if (transform.rotation.y <= 0)
        {
            if (Input.GetKey(keyLeft))
            {
                transform.position -= new Vector3(Speed * Time.deltaTime, 0);
                if (transform.position.x < -boundX)
                {
                    transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
                }
            }
            if (Input.GetKey(keyRight))
            {
                transform.position += new Vector3(Speed * Time.deltaTime, transform.position.y);
                if (transform.position.x > boundX)
                {
                    transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
                }
            }
        }
        else
        {
            if (Input.GetKey(keyLeft))
            {
                transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
                if (transform.position.z < -boundZ)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + .2f);
                }
            }
            if (Input.GetKey(keyRight))
            {
                transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
                if (transform.position.z > boundZ)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - .2f);
                }
            }
        }        
    }
}
