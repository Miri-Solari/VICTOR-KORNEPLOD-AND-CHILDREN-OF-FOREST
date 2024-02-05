using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasAsket : BaseEvent
{
    [SerializeField] int _numberOfFutureAskets;
    protected override void Awake()
    {
        base.Awake();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Minus(other.gameObject);
    }

    private void Minus(GameObject target)
    {
        var temp = target.GetComponent<Lizard>();
        Invoke(nameof(temp.SelfDestroy), 0.2f);
    }
}
