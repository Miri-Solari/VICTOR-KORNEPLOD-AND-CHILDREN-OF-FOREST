using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiken : Animal
{
    public Animator animator;
    protected override void OnTriggerEnter(Collider other)
    {
        DMG = 0;
        other.GetComponent<Lizard>().HalfHp();
        base.OnTriggerEnter(other);

        if (_currentLizardcount < MaxLizardCount)
        {
            animator.SetBool("attack", true);

            CancelInvoke("ResetAttackAnimation");
            Invoke("ResetAttackAnimation", 2f);
        }
    }

    void ResetAttackAnimation()
    {
        animator.SetBool("attack", false);
    }
}
