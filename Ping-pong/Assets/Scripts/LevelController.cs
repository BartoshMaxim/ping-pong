using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public Transform ball;
    public Vector2 fieldSize;
    public Platform[] platform;

    UsersMoveKeys userKeys;
    public enum Id
    {
        top,
        bot,
        left,
        right
    }
    private void Start()
    {
        ball.position = new Vector3(Random.Range(-fieldSize.x / 2 + 3.5f, fieldSize.x / 2), 0, Random.Range(-fieldSize.y / 2 + 3.5f, fieldSize.y / 2));
        userKeys = new UsersMoveKeys
        {
            Player1MoveLeft = KeyCode.A,
            Player1MoveRight = KeyCode.D,
            Player2MoveLeft = KeyCode.H,
            Player2MoveRight = KeyCode.K,
            Player3MoveLeft = KeyCode.LeftArrow,
            Player3MoveRight = KeyCode.RightArrow,
            Player4MoveLeft = KeyCode.Keypad4,
            Player4MoveRight = KeyCode.Keypad6
        };

        BallMovement.MinSpeed = 1;
        BallMovement.MaxSpeed = 9;
        BallMovement.BallSpeed = 3;
        foreach (Platform p in platform)
        {
            p.GetComponent<Platform>().Speed = 6f;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (BallMovement.BallSpeed > BallMovement.MinSpeed)
            {
                BallMovement.BallSpeed--;
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (BallMovement.BallSpeed < BallMovement.MaxSpeed)
            {
                BallMovement.BallSpeed++;
            }
        }

        platform[0].MovePlatform(userKeys.Player1MoveLeft, userKeys.Player1MoveRight);
        platform[0].Id = (int)Id.bot;
        platform[1].MovePlatform(userKeys.Player2MoveLeft, userKeys.Player2MoveRight);
        platform[1].Id = (int)Id.top;
        platform[2].MovePlatform(userKeys.Player3MoveLeft, userKeys.Player3MoveRight);
        platform[2].Id = (int)Id.left;
        platform[3].MovePlatform(userKeys.Player4MoveLeft, userKeys.Player4MoveRight);
        platform[3].Id = (int)Id.right;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(fieldSize.x, 1, fieldSize.y));
    }
}
