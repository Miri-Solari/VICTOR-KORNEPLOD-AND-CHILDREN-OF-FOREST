using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject CurrentMenu;

    public void Click()
    {
        CurrentMenu.SetActive(true);
        PauseMenu.SetActive(false);

        Time.timeScale = 1f;
    }
}
