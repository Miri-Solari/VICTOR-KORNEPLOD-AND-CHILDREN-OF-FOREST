using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cock : Animal
{
    MonoBehaviour TrapPoints;
    [SerializeField] private int point = 3;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponentInChildren<Hangover>())
        {
            //TrapPoints.AddPoints(point);
        }
        base.OnTriggerEnter(other);
    }
}
