using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiken : Animal
{
    public Animator animator;
    public bool attack;

    protected override void OnTriggerEnter(Collider other)
    {
        DMG = 0;
        other.GetComponent<Lizard>().HalfHp();
        base.OnTriggerEnter(other);

        if (_currentLizardcount < MaxLizardCount)
        {
            animator.SetBool("attack", true);
            attack = true;

            CancelInvoke("ResetAttackAnimation");
            Invoke("ResetAttackAnimation", 2f);
        }

        if (_currentLizardcount < 1)
        {
            SoundManager.Instance.PlaySound(13);
        }
    }

    void ResetAttackAnimation()
    {
        animator.SetBool("attack", false);
        attack = false;
    }
}
