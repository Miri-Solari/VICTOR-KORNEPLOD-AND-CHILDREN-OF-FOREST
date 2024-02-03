using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour 
{
    public int MaxLizardCount = 10;
    public float DMG = 1;
    public Effect effect;
    private int _currentLizardcount = 0;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("lizard") && _currentLizardcount < MaxLizardCount)
        {
            Lizard lizard = other.gameObject.GetComponent<Lizard>();
            lizard.TakeDamege(DMG);
            Instantiate(effect, lizard.transform);
            _currentLizardcount++;
            Debug.Log("work");
        }
    }
}
