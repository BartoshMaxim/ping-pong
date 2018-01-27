using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public Transform ball;
    public Vector2 fieldSize;
    public Platform[] platform;


    public KeyCode PlayerOneLeft;
    public KeyCode PlayerOneRight;
    public KeyCode PlayerTwoLeft;
    public KeyCode PlayerTwoRight;
    public KeyCode PlayerThreeLeft;
    public KeyCode PlayerThreeRight;
    public KeyCode PlayerFourLeft;
    public KeyCode PlayerFourRight;

    private void Start()
    {
        foreach (Platform p in platform)
        {
            p.GetComponent<Platform>().Speed = 6f;
        }
    }

    private void Update()
    {
        platform[0].MovePlatform(PlayerOneLeft, PlayerOneRight);
        platform[1].MovePlatform(PlayerTwoLeft, PlayerTwoRight);
        platform[2].MovePlatform(PlayerThreeLeft, PlayerThreeRight);
        platform[3].MovePlatform(PlayerFourLeft, PlayerFourRight);

        if (ball.position.x > fieldSize.x / 2 || ball.position.x < -fieldSize.x / 2 || ball.position.z > fieldSize.y / 2 || ball.position.z < -fieldSize.y / 2)
        {

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(fieldSize.x, 1, fieldSize.y));
    }
}
