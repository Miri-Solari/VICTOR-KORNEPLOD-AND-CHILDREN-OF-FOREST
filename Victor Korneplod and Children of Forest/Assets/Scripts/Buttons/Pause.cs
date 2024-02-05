using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject CurrentMenu;
    public void Click()
    {
        PauseMenu.SetActive(true);
        CurrentMenu.SetActive(false);
        Time.timeScale = 0f;
    }
}
