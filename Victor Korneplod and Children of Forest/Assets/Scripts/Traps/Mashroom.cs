using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mashroom : BaseTrap
{
    [SerializeField] float _minDmg;
    [SerializeField] float _maxDmg;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (_lizard != null)
        {
            float dmg = Random.Range(_minDmg, _maxDmg);
            _lizard.TakeDamege(dmg);
        }
    }
}
