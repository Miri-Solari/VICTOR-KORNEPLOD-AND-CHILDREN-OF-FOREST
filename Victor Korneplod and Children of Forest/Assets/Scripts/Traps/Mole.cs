using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mole : BaseTrap
{
    [SerializeField] Slow _effect;
    AudioSource moleSound;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (_lizard != null)
        {
            if (_effect != null)
            {
                Instantiate(_effect, _lizard.transform);
            }
        }
    }
}
