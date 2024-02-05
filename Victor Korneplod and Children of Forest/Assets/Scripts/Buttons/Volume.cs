using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] GameObject source;
    private AudioSource sourceAudio;
    private Slider slider;
    void Awake()
    {
        sourceAudio = source.GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
        //sourceAudio.volume = 1 - slider.value;

    }

    private void FixedUpdate()
    {
        sourceAudio.volume = 1 - slider.value;
    }

}
