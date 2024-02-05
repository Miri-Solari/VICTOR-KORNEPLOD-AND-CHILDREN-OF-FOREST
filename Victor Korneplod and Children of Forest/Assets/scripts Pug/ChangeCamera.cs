using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    void Awake()
    {
        MoveToTarget.TargetReachedEvent += Change;
    }

    void OnDestroy()
    {
        MoveToTarget.TargetReachedEvent -= Change;
    }

    public void Change(float time)
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
    }
}
