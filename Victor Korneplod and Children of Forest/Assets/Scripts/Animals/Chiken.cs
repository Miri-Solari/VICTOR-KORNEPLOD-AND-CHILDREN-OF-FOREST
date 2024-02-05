using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiken : Animal
{
    protected override void OnTriggerEnter(Collider other)
    {
        DMG = 0;
        other.GetComponent<Lizard>().HalfHp();
        base.OnTriggerEnter(other);
    }
}
