using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Animal
{
    [SerializeField] private float _dmgMulti;
    public Animator auf;
    public Animator auf2;
    public Animator auf3;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hangover>(out Hangover temp))
        {
            DMG *= _dmgMulti;
        }

        // Запуск анимации атаки
        if (_currentLizardcount < MaxLizardCount && auf != null &&  !auf.GetBool("attack") && !auf2.GetBool("attack") && !auf3.GetBool("attack"))
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
        auf3.SetBool("attack", true);
        yield return new WaitForSeconds(0.9f);
        auf.SetBool("attack", false);
        auf2.SetBool("attack", false);
        auf3.SetBool("attack", false);
    }
}
