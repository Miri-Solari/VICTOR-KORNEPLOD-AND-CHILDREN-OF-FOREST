using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public void Click()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
