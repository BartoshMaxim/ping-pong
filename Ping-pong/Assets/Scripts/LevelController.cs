using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public Transform ball;
    public Vector2 fieldSize;
    public Platform[] platform;
    public static int Points { get; set; }
    bool bonusTaken = false;
    UsersMoveKeys userKeys;
    int bonus = -1;

    public enum Id
    {
        top,
        bot,
        left,
        right
    }

    enum Bonuses
    {
        DoublePlatform,
        DoubleBall,
        AdditionalPoints
    }

    private void Start()
    {
        ball.position = new Vector3(Random.Range(-3.5f, 3.5f), 0, Random.Range(-3.5f, 3.5f));
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
        BallMovement.BallSpeed = 6;
        foreach (Platform p in platform)
        {
            p.GetComponent<Platform>().Speed = 6f;
        }
    }

    void BonusPoints()
    {
        if (platform[0].transform.position.x < -8f && platform[1].transform.position.x > 8f && platform[2].transform.position.z > 8f && platform[3].transform.position.z < 8f)
        {
            Points += Bonus.AdditionalPoints;
        }
    }
    private void Update()
    {
        platform[0].MovePlatform(userKeys.Player1MoveLeft, userKeys.Player1MoveRight);
        platform[0].Id = (int)Id.bot;
        platform[1].MovePlatform(userKeys.Player2MoveLeft, userKeys.Player2MoveRight);
        platform[1].Id = (int)Id.top;
        platform[2].MovePlatform(userKeys.Player3MoveLeft, userKeys.Player3MoveRight);
        platform[2].Id = (int)Id.left;
        platform[3].MovePlatform(userKeys.Player4MoveLeft, userKeys.Player4MoveRight);
        platform[3].Id = (int)Id.right;
        
        switch (bonus)
        {
            case (int)Bonuses.AdditionalPoints:
                {
                    BonusPoints();
                    break;
                }
            case (int)Bonuses.DoubleBall:
                {
                    Bonus.DoubleBall();
                    break;
                }
            case (int)Bonuses.DoublePlatform:
                {
                    Bonus.DoublePlatform(platform[BallMovement.LastPlatformId]);
                    break;
                }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(fieldSize.x, 1, fieldSize.y));
    }
}
