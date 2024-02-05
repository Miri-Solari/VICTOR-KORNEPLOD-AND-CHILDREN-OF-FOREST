using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour 
{
    public int MaxLizardCount = 10;
    public float DMG = 1;
    public Effect effect;
    protected int _currentLizardcount = 0;
    protected virtual void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("lizard") && _currentLizardcount < MaxLizardCount)
        {
            Lizard lizard = other.gameObject.GetComponent<Lizard>();
            lizard.TakeDamege(DMG);
            if (effect != null)
            {
                Debug.Log("norm");
                Instantiate(effect, lizard.transform);
            }
            _currentLizardcount++;
        }
    }
}
