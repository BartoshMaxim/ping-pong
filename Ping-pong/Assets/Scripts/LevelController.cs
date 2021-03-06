﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Logger;
using Assets.Scripts.Session;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    private static string _tag = "LevelController";
    public Transform ball;
    public Platform[] platform;
    public static int Points { get; set; }
    bool bonusTaken = false;
    UsersMoveKeys userKeys;
    int bonus = -1;

    AudioSource audio;

    private Logger _logger;
    private DateTime timeCreate;
<<<<<<< HEAD
    
=======

>>>>>>> 9716b6689bf8bec178990f4a4a5c94c47d09c3da
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
        audio = GetComponent<AudioSource>();
        Points = 0;
        ball.position = new Vector3();
        userKeys = Menu.UsersMoveKeys;
        _logger = new UnityEngine.Logger(new PingPongLogHandler());
        _logger.Log(_tag, "Session Start.");
        timeCreate = DateTime.Now;

        foreach (Platform p in platform)
        {
            p.GetComponent<Platform>().Speed = 5f;
        }
        platform[0].Id = (int)Id.bot;
        platform[1].Id = (int)Id.top;
        platform[2].Id = (int)Id.left;
        platform[3].Id = (int)Id.right;
    }

    private void Update()
    {
        platform[0].MovePlatform(userKeys.Player1MoveLeft, userKeys.Player1MoveRight, platform[0].Id);
        platform[1].MovePlatform(userKeys.Player2MoveLeft, userKeys.Player2MoveRight, platform[1].Id);
        platform[2].MovePlatform(userKeys.Player3MoveLeft, userKeys.Player3MoveRight, platform[2].Id);
        platform[3].MovePlatform(userKeys.Player4MoveLeft, userKeys.Player4MoveRight, platform[3].Id);

        if (ball.transform.position.x < -7f
           || ball.transform.position.x > 7f
           || ball.transform.position.z > 7f
            || ball.transform.position.z < -7f)
        {
            Exit("Мяч вылетел за границы поля");
        }
        print(Points);
        if (!bonusTaken)
        {
                print("SS");
            if (platform[0].transform.position.x < -3.5f
           && platform[1].transform.position.x > 3.5f
           && platform[2].transform.position.z > 3.5f
            && platform[3].transform.position.z < -3.5f)
            {
                bonusTaken = true;
                bonus = (int)Bonuses.AdditionalPoints;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bonus = (int)Bonuses.DoublePlatform;
        }

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
    public void Exit(string nameDeath)
    {
        SaveResults(nameDeath);
        SceneManager.LoadScene("Statistics");
    }

    /// <summary>
    /// Save Results and start new scene
    /// </summary>
    public void SaveResults(string nameDeath)
    {
        try
        {
            var spendTime = DateTime.Now - timeCreate;

            Debug.Log("TimeCreate " + timeCreate);
            Debug.Log("Spend " + spendTime.ToString());
            Debug.Log("Death " + nameDeath);
            Debug.Log("Points " + Points);

            SessionResult sessionResult = new SessionResult(timeCreate, spendTime, nameDeath, Points);
            Menu.SessionList.Sessions.Add(sessionResult);
            Menu.SessionList.Save();
        }
        catch (System.Exception e)
        {
            _logger.LogException(e);
        }
    }
}
