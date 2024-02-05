using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirt : Animal
{
    public Animator auf;
    public Animator auf2;

    [SerializeField] private float _dmgMulti;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponentInChildren<Slow>())
        {
            DMG *= _dmgMulti;
        }

        if (_currentLizardcount < 1)
        {
            int randomNumber = Random.Range(1, 3);
            if (randomNumber == 1) SoundManager.Instance.PlaySound(7);
            if (randomNumber == 2) SoundManager.Instance.PlaySound(8);
        }

        if (_currentLizardcount < MaxLizardCount && auf != null && !auf.GetBool("attack") && !auf2.GetBool("attack"))
        {
            StartCoroutine(TriggerAttackAnimation());
        }

        base.OnTriggerEnter(other);

      
    }

    private IEnumerator TriggerAttackAnimation()
    {
        Debug.Log(_currentLizardcount);
        auf.SetBool("attack", true);
        auf2.SetBool("attack", true);
        yield return new WaitForSeconds(0.9f);
        auf.SetBool("attack", false);
        auf2.SetBool("attack", false);
    }
}
