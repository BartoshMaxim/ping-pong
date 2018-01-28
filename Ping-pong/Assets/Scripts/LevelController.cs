using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public Transform ball;
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
        //ball.position = new Vector3(Random.Range(-35f, 35f), 0, Random.Range(-35f, 35f));
        ball.position = new Vector3();
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

        foreach (Platform p in platform)
        {
            p.GetComponent<Platform>().Speed = 50f;
        }
    }
    
    private void Update()
    {
        if (!bonusTaken)
        {
            if (platform[0].transform.position.x < -49f
           && platform[1].transform.position.x > 49f
           && platform[2].transform.position.z > 49f
            && platform[3].transform.position.z < -49f)
            {
                bonusTaken = true;
                bonus = (int)Bonuses.AdditionalPoints;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bonus = (int)Bonuses.DoublePlatform;
        }
        platform[0].MovePlatform(userKeys.Player1MoveLeft, userKeys.Player1MoveRight);
        platform[0].Id = (int)Id.bot;
        platform[1].MovePlatform(userKeys.Player2MoveLeft, userKeys.Player2MoveRight);
        platform[1].Id = (int)Id.top;
        platform[2].MovePlatform(userKeys.Player3MoveLeft, userKeys.Player3MoveRight);
        platform[2].Id = (int)Id.left;
        platform[3].MovePlatform(userKeys.Player4MoveLeft, userKeys.Player4MoveRight);
        platform[3].Id = (int)Id.right;
        print(Points);
        switch (bonus)
        {
            case (int)Bonuses.AdditionalPoints:
                {
                    Points += Bonus.AdditionalPoints;
                    bonus = -1;
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
}
