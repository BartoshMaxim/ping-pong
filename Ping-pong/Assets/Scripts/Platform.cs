using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public float Size { get; set; }
    public float Speed { get; set; }
    public int Id { get; set; }

    float platformScale = 3;

    private void Start()
    {
        transform.localScale = new Vector3(transform.lossyScale.x, transform.lossyScale.y, platformScale);
    }

    public void MovePlatform(KeyCode keyLeft, KeyCode keyRight)
    {
        if (transform.rotation.y == 0)
        {
            if (Input.GetKey(keyLeft))
            {
                transform.position -= new Vector3(0, 0, Speed * Time.deltaTime);
                if (transform.position.z < -8.5f)
                {
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z + .3f);
                }
            }
            if (Input.GetKey(keyRight))
            {
                transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
                if (transform.position.z > 8.5f)
                {
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z - .3f);
                }
            }
        }
        else
        {
            if (Input.GetKey(keyLeft))
            {
                transform.position -= new Vector3(Speed * Time.deltaTime, 0);
                if (transform.position.x < -8.5f)
                {
                    transform.position = new Vector3(transform.position.x + .3f, 0, transform.position.z);
                }
            }
            if (Input.GetKey(keyRight))
            {
                transform.position += new Vector3(Speed * Time.deltaTime, transform.position.y);
                if (transform.position.x > 8.5f)
                {
                    transform.position = new Vector3(transform.position.x - .3f, 0, transform.position.z);
                }
            }
        }        
    }
}
