using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject CurrentMenu;
    public AudioSource Sound;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PAUSEPOCHINKA.ISPAUSED) Click();
        }
    }
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
