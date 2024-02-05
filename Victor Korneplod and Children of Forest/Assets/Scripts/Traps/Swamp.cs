using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : BaseTrap
{
    [SerializeField] float dmg;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (_lizard != null)
        {
            if (!_lizard.IsFullHP())
            {
                _lizard.TakeDamege(dmg);
            }
        }
    }
}
