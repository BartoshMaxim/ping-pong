using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public static float BallSpeed { get; set; }
    public static float MaxSpeed { get; set; }
    public static float MinSpeed { get; set; }
    public SpriteRenderer emoji;
    public Sprite[] sprite;
    int newEmoji;
    void Start ()
    {
        if (transform.position.x < -4)
        GetComponent<Rigidbody>().velocity = Vector3.right * BallSpeed;
        else if (transform.position.x > 4)
            GetComponent<Rigidbody>().velocity = Vector3.left * BallSpeed;
        else
            GetComponent<Rigidbody>().velocity = Vector3.right * BallSpeed;

    }

    private void Update()
    {
        if (newEmoji == 4)
        {
            emoji.sprite = sprite[Random.Range(0,25)];
            newEmoji = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            newEmoji++;
            switch (collision.gameObject.GetComponent<Platform>().Id)
            {
                case (int)LevelController.Id.left:
                    {
                        float z = (transform.position.z - collision.gameObject.transform.position.z) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(1, 0, z);
                        GetComponent<Rigidbody>().velocity = dir * BallSpeed;
                        break;
                    }
                case (int)LevelController.Id.right:
                    {
                        float z = (transform.position.z - collision.gameObject.transform.position.z) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(-1, 0, z);
                        GetComponent<Rigidbody>().velocity = dir * BallSpeed;
                        break;
                    }
                case (int)LevelController.Id.bot:
                    {
                        float x = (transform.position.x - collision.gameObject.transform.position.x) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(x, 0, 1);
                        GetComponent<Rigidbody>().velocity = dir * BallSpeed;
                        break;
                    }
                case (int)LevelController.Id.top:
                    {
                        float x = (transform.position.x - collision.gameObject.transform.position.x) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(x, 0, -1);
                        GetComponent<Rigidbody>().velocity = dir * BallSpeed;
                        break;
                    }
            }
        }
    }
}
