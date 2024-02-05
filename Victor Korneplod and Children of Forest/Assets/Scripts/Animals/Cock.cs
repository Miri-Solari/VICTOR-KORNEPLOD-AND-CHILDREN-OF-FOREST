using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cock : Animal
{
    public Animator Coc;
    MonoBehaviour TrapPoints;
    [SerializeField] private int point = 3;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponentInChildren<Hangover>())
        {
            //TrapPoints.AddPoints(point);
        }

        if (_currentLizardcount < 1)
        {
            int randomNumber = Random.Range(1, 3);
            if (randomNumber == 1) SoundManager.Instance.PlaySound(5);
            if (randomNumber == 2) SoundManager.Instance.PlaySound(6);
        }

        if (_currentLizardcount < MaxLizardCount && Coc != null && !Coc.GetBool("attack"))
        {
            StartCoroutine(TriggerAttackAnimation());
        }

        base.OnTriggerEnter(other);
    }

    private IEnumerator TriggerAttackAnimation()
    {
        Debug.Log(_currentLizardcount);
        Coc.SetBool("attack", true);
        yield return new WaitForSeconds(0.9f);
        Coc.SetBool("attack", false);

    }
}
