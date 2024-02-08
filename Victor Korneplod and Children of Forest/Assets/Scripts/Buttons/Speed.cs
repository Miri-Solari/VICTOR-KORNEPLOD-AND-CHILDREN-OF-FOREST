using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public static float TimeSpeed = 1f;
    public float _timeSpeed;
    public void Click()
    {
        TimeSpeed = _timeSpeed;
        Time.timeScale = _timeSpeed;
    }

    private void Awake()
    {
        TimeSpeed = 1f;
    }
}
