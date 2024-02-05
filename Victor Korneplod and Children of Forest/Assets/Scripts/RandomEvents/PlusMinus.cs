using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinus : BaseEvent
{
    GameObject prefab;
    private float rand = 0;
    protected override void Awake()
    {
        rand = Random.Range(-23, 23);
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lizrd")
        {
            if (rand > 0) Plus();
        }
        else Minus(other.gameObject);
    }

    private void Plus()
    {
        Instantiate(prefab);
    }

    private void Minus(GameObject target)
    {
        var temp = target.GetComponent<Lizard>();
        Invoke(nameof(temp.SelfDestroy), 0.2f);
    }
}
