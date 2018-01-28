using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    
    public static int LastPlatformId { get; set; }
    public SpriteRenderer emoji;
    public Sprite[] sprite;
    private int newEmoji;
    private int emojiName;
    private float speed;
    void Start ()
    {
        speed = 50f;
        emojiName = 1;
        //if (transform.position.x <= 0)
        //    GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed;//right
        //else if (transform.position.x > 0)
        //    GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, -1) * speed;

        GetComponent<Rigidbody>().velocity = Vector3.left * speed;
    }
    private void Update()
    {
        EmojiSwap();
    }

    private void EmojiSwap()
    {
        if (newEmoji >= 4)
        {
            newEmoji = 0;
            emojiName++;
            if (emojiName < 116)
                emoji.sprite = Resources.Load<Sprite>("emoji/" + emojiName);
            else
                emojiName = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Platform>())
        {
            LevelController.Points+=50;
            newEmoji++;
            collision.gameObject.GetComponentInParent<Platform>().PlayAnimation();
            switch (collision.gameObject.GetComponentInParent<Platform>().Id)
            {
                case (int)LevelController.Id.left:
                    {
                        LastPlatformId = (int)LevelController.Id.left;
                        float z = (transform.position.z - collision.gameObject.transform.position.z) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(1, 0, z);
                        GetComponent<Rigidbody>().velocity = dir * speed;
                        break;
                    }
                case (int)LevelController.Id.right:
                    {
                        LastPlatformId = (int)LevelController.Id.right;
                        float z = (transform.position.z - collision.gameObject.transform.position.z) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(-1, 0, z);
                        GetComponent<Rigidbody>().velocity = dir * speed;
                        break;
                    }
                case (int)LevelController.Id.bot:
                    {
                        LastPlatformId = (int)LevelController.Id.bot;
                        float x = (transform.position.x - collision.gameObject.transform.position.x) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(x, 0, 1);
                        GetComponent<Rigidbody>().velocity = dir * speed;
                        break;
                    }
                case (int)LevelController.Id.top:
                    {
                        LastPlatformId = (int)LevelController.Id.top;
                        float x = (transform.position.x - collision.gameObject.transform.position.x) / collision.collider.bounds.size.y;
                        Vector3 dir = new Vector3(x, 0, -1);
                        GetComponent<Rigidbody>().velocity = dir * speed;
                        break;
                    }
            }
        }
    }
}
