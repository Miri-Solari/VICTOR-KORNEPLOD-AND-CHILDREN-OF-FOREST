using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slow : Effect
{
    public float SlowMulti;
    private float _startSpeed;

    private void Start()
    {
        
        if (Target.CompareTag("lizard"))
        {
            LizardMove lizard = Target.GetComponent<LizardMove>();
            _startSpeed = lizard.Speed;
            lizard.Speed = _startSpeed * SlowMulti;
        }
    }

    private void FixedUpdate()
    {
        time-= Time.deltaTime;
        if (time < 0 )
        {
            if (Target.CompareTag("lizard"))
            {
                LizardMove lizard = Target.GetComponent<LizardMove>();
                lizard.Speed = _startSpeed;
            }
        }
    }
}
