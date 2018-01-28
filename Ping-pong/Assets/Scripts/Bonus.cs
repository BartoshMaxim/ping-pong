using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    public static int AdditionalPoints
    {
        get { return 1000; }
    }

    public static void DoublePlatform(Platform platform)
    {
        GameObject doublePlatform = Instantiate(Resources.Load("lastik2")) as GameObject;
        //Destroy(platform);
        doublePlatform.AddComponent<Platform>();
    }

    public static void DoubleBall()
    {
        var newBall = Instantiate(Resources.Load("Ball"));
    }
}
