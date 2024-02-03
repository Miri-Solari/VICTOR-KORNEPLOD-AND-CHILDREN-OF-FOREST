using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Animal
{
    [SerializeField] private float _dmgMulti;
    protected override void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Hangover>(out Hangover temp))
        {
            DMG *= _dmgMulti;
        }
        base.OnTriggerEnter(other);
    }
}
