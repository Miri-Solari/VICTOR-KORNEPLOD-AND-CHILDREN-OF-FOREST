using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour 
{
    public int MaxLizardCount = 10;
    public float DMG = 1;
    public Effect effect;
    protected int _currentLizardcount = 0;
    private float _baseDmg;

    private void Awake()
    {
        _baseDmg = DMG;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("lizard") && _currentLizardcount < MaxLizardCount)
        {
            Lizard lizard = other.gameObject.GetComponent<Lizard>();
            lizard.TakeDamege(DMG);
            DMG = _baseDmg;
            if (effect != null)
            {
                Debug.Log("norm");
                Instantiate(effect, lizard.transform);
            }
            _currentLizardcount++;
        }
    }
}
