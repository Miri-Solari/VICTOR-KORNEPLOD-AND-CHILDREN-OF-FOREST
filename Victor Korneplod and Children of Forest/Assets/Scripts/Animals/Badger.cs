using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badger : Animal
{
    public Animator Bar;
    protected override void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Lizard>().AddTenPercHP();

        if (_currentLizardcount < 1)
        {
            SoundManager.Instance.PlaySound(2);
        }

        if (Bar != null && !Bar.GetBool("attack"))
        {
            StartCoroutine(TriggerAttackAnimation());
        }

        base.OnTriggerEnter(other);
    }

    private IEnumerator TriggerAttackAnimation()
    {
        Debug.Log(_currentLizardcount);

        Bar.SetBool("attack", true);
        yield return new WaitForSeconds(2f);
        Bar.SetBool("attack", false);
    }
}
