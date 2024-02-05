using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirt : Animal
{
    [SerializeField] private float _dmgMulti;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Slow>(out Slow temp))
        {
            DMG *= _dmgMulti;
        }
        base.OnTriggerEnter(other);
    }
}
