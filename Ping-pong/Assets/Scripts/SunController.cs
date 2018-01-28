using System;
using UnityEngine;

public class SunController : MonoBehaviour
{

    private Vector3 day = new Vector3(90f, 0, 0);

    private Vector3 night = new Vector3(165f, 0, 0);

    private bool isDay;

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now.Hour > 18 && isDay)
        {
            isDay = false;
            transform.eulerAngles = night;
        }
        else if (DateTime.Now.Hour > 6 && !isDay)
        {
            isDay = true;
            transform.eulerAngles = day;
        }
    }
}
