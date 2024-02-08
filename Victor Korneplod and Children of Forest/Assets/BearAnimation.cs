using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimation : MonoBehaviour
{

    public TrailRenderer[] slashes;

    public void Slash(string type)
    {
        Debug.Log(type);
        if(type == "Start")
        {
            SoundManager.Instance.PlayAttackSound(9);
            foreach(TrailRenderer a in slashes)
            {
                a.emitting = true;
            }

        }
        if(type == "End")
        {
            foreach (TrailRenderer a in slashes)
            {
                a.emitting = false;
            }
        }
    }
}
