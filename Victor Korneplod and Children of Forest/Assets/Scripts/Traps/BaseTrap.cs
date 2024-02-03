using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    MonoBehaviour TrapPoints;
    protected Lizard _lizard;
    public int count;

    private void Awake()
    {
        //TrapPoints.UsePoints(count);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lizard"))
        {
            _lizard = other.gameObject.GetComponent<Lizard>();

        }
    }
}
