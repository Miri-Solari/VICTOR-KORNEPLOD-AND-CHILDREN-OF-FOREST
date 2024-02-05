using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal
{
    [SerializeField] float _dmgMilti;
    [SerializeField] float _dmgMiltiHang;
    [SerializeField] float _dmgMiltiSlow;
    [SerializeField] float _dmgMiltiDist;
    public Animator RuR;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponentInChildren<Hangover>())
        {
            DMG *= _dmgMiltiHang;
        }
        if (other.transform.GetComponentInChildren<Slow>())
        {
            DMG *= _dmgMiltiSlow;
        }
        if (other.transform.GetComponentInChildren<Distraction>())
        {
            DMG *= _dmgMiltiDist;
        }

        if (_currentLizardcount < MaxLizardCount && RuR != null && !RuR.GetBool("attack"))
        {
            StartCoroutine(TriggerAttackAnimation());
        }

        base.OnTriggerEnter(other);
    }

    private IEnumerator TriggerAttackAnimation()
    {
        Debug.Log(_currentLizardcount);
        RuR.SetBool("attack", true);
        yield return new WaitForSeconds(0.9f);
        RuR.SetBool("attack", false);

    }

}
