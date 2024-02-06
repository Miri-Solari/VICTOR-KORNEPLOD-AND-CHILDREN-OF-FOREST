using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    [SerializeField] AudioSource sourceAudio;

    public void Chanched()
    {
        Slider slider = GetComponent<Slider>();
        sourceAudio.volume = 1 - slider.value;
    }

    

}
