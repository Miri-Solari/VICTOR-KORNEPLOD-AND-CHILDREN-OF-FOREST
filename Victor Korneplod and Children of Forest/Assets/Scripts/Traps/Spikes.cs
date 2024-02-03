using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : BaseTrap
{
    [SerializeField] float _dmg;
    [SerializeField] int _maxLizardCount;
    private int _lizardCount;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (_lizard != null && _lizardCount < _maxLizardCount)
        {
            _lizard.TakeDamege(_dmg);
            _lizardCount++;
        }
    }
}
