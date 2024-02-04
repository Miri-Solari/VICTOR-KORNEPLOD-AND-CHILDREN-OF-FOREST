using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal
{
    [SerializeField] float _dmgMilti;
    [SerializeField] float _dmgMiltiHang;
    [SerializeField] float _dmgMiltiSlow;
    [SerializeField] float _dmgMiltiDist;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hangover>(out Hangover temp))
        {
            DMG *= _dmgMiltiHang;
        }
        if (other.TryGetComponent<Slow>(out Slow temp1))
        {
            DMG *= _dmgMiltiSlow;
        }
        if (other.TryGetComponent<Distraction>(out Distraction temp2))
        {
            DMG *= _dmgMiltiDist;
        }

        base.OnTriggerEnter(other);
    }
}
