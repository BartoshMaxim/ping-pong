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
        platform.transform.localScale = new Vector3(platform.transform.localScale.x, platform.transform.localScale.y, platform.transform.localScale.z * 2);
    }

    public static void DoubleBall()
    {
        var newBall = Instantiate(Resources.Load("Ball"));
    }
}
