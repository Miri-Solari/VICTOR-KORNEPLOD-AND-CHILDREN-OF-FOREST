using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject CurrentMenu;
    public AudioSource Sound;
    public void Click()
    {
        PauseMenu.SetActive(true);
        CurrentMenu.SetActive(false);
        PAUSEPOCHINKA.ISPAUSED = true;
        if (Sound.isPlaying)
        {
            Sound.Pause();
            PAUSEPOCHINKA.ISPAUSESOUND = true;
        }

        Time.timeScale = 0f;
    }
}
