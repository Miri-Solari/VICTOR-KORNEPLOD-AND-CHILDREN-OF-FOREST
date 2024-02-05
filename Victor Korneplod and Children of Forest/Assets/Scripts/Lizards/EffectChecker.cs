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
        if (_lizard.transform.GetComponentInChildren<Hangover>())
        {
            HangEffect.SetActive(true);
        }
        else HangEffect.SetActive(false);


        if (_lizard.transform.GetComponentInChildren<Slow>())
        {
            SlowEffect.SetActive(true);
        }
        else SlowEffect.SetActive(false);


        if (_lizard.transform.GetComponentInChildren<Distraction>())
        {
            DistEffect.SetActive(true);
        }
        else DistEffect.SetActive(false);


        if (_lizard.transform.GetComponentInChildren<Flame>())
        {
            FlameEffect.SetActive(true);
        }
        else FlameEffect.SetActive(false);

    }
}
