using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectChecker : MonoBehaviour
{
    [SerializeField] GameObject _lizard;
    [SerializeField] GameObject FlameEffect;
    [SerializeField] GameObject SlowEffect;
    [SerializeField] GameObject HangEffect;
    [SerializeField] GameObject DistEffect;

    private void Start()
    {
        HangEffect.SetActive(false);
        SlowEffect.SetActive(false);
        DistEffect.SetActive(false);
        FlameEffect.SetActive(false);
    }

    void Update()
    {
        if (_lizard.TryGetComponent<Hangover>(out Hangover temp))
        {
            HangEffect.SetActive(true);
        }
        else HangEffect.SetActive(false);


        if (_lizard.TryGetComponent<Slow>(out Slow temp1))
        {
            SlowEffect.SetActive(true);
        }
        else SlowEffect.SetActive(false);


        if (_lizard.TryGetComponent<Distraction>(out Distraction temp2))
        {
            DistEffect.SetActive(true);
        }
        else DistEffect.SetActive(false);


        if (_lizard.TryGetComponent<Flame>(out Flame temp3))
        {
            FlameEffect.SetActive(true);
        }
        else FlameEffect.SetActive(false);

    }
}
