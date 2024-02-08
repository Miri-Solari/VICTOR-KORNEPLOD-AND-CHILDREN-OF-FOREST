using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Click()
    {
        Time.timeScale = 1f;
        PAUSEPOCHINKA.ISPAUSED = false;
        SceneManager.LoadScene("MainMenu");
    }
}
