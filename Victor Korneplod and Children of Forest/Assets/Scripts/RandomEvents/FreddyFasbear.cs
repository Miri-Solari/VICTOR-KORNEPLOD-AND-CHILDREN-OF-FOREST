using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddyFasbear : BaseEvent
{
    [SerializeField] GameObject _enemys;
    protected override void Awake()
    {
        base.Awake();
        var listOfEnemy = _enemys.transform.GetComponentsInChildren<GameObject>();
        for (int x = 0; x < listOfEnemy.Length; x++)
        {
            if (listOfEnemy[x].tag == "lizard")
            {
                var temp = listOfEnemy[x].GetComponent<Lizard>();
                Invoke(nameof(temp.SelfDestroy), 1f);
            }
        }
    }

}
