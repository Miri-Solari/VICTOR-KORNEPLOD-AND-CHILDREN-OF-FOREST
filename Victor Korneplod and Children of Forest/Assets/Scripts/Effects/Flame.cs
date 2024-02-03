using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : Effect
{
    public float DmgPerSec = 0;


    protected override void Awake()
    {
        InvokeRepeating(nameof(Fire), 0.2f, 1.0f);
        base.Awake();
    }

    private void Fire()
    {
            Lizard lizard = Target.GetComponent<Lizard>();
            lizard.TakeDamege(DmgPerSec);
    }
}
