using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : MonoBehaviour
{
    public ParticleSystem[] punches;
    public bool main = false;
    public void Punch(int type)
    {
        if (type == 1)
        {
            if (main) { SoundManager.Instance.PlayAttackSound(10); }
            punches[0].Play();
        }
        if (type == 2)
        {
            if (main) { SoundManager.Instance.PlayAttackSound(11); }
            punches[1].Play();
        }
    }

}
