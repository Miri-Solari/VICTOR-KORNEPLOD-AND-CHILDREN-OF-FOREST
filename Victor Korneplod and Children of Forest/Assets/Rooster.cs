using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooster : MonoBehaviour
{
    public ParticleSystem roar;

    public void Roar(string type)
    {
        if (type == "Pre")
        {
            SoundManager.Instance.PlayAttackSound(12);
        }
        if (type == "Start")
        {
            roar.Play();
        }
    }
}
