using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorneplodScript : MonoBehaviour
{

    public Animator KorneVictor;

    void Start()
    {
        Invoke("AnimationChange", 10f);
    }

    void AnimationChange()
    {
        int EVENT = Random.Range(0, 4);
        KorneVictor.SetInteger("Event", Mathf.Clamp(EVENT - 1, 0, 3));
        Invoke("AnimationChange", 10f);
    }

}
