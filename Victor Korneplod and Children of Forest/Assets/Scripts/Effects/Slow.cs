using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slow : Effect
{
    public float SlowMulti;
    private float _startSpeed;

    protected override void Awake()
    {
        base.Awake();
        if (Target.CompareTag("lizard"))
        {
            LizardMove lizard = Target.GetComponent<LizardMove>();
            _startSpeed = lizard.Speed;
            lizard.Speed = _startSpeed * SlowMulti;
            
        }
    }

    protected override void FixedUpdate()
    {
        time-= Time.deltaTime;
        if (time <= 0 )
        {
            if (Target.CompareTag("lizard"))
            {
                LizardMove lizard = Target.GetComponent<LizardMove>();
                Debug.Log($"{_startSpeed}  {lizard.Speed}");
                lizard.Speed = _startSpeed;
                Destroy(gameObject);
            }
        }
    }
}
