using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : BaseTrap
{
    [SerializeField] float dmg;
    private int _curr = 0;
    protected override void OnTriggerEnter(Collider other)
    {
        if (_curr < 1)
        {
            SoundManager.Instance.PlaySound(Random.Range(21, 23));
            _curr = 1;
        }
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
