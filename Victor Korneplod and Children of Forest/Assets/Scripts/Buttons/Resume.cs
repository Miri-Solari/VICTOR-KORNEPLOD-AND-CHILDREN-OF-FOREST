using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject CurrentMenu;
    public AudioSource Sound;

    public void Click()
    {
        CurrentMenu.SetActive(true);
        PauseMenu.SetActive(false);
        
        if (PAUSEPOCHINKA.ISPAUSESOUND) Sound.UnPause();
        PAUSEPOCHINKA.ISPAUSESOUND = false;
        PAUSEPOCHINKA.ISPAUSED = false;
        Time.timeScale = 1f;
    }
}
