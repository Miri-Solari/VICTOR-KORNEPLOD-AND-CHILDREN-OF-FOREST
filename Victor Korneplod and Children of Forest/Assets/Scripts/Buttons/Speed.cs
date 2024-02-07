using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float _timeSpeed;
    public void Click()
    {
        Time.timeScale = _timeSpeed;
    }
}
