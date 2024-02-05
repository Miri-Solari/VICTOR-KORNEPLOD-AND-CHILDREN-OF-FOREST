using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject PauseMenu;

    public void Click()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
