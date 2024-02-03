using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badger : Animal
{
    protected override void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Lizard>().AddTenPercHP();
        base.OnTriggerEnter(other);
    }
}
