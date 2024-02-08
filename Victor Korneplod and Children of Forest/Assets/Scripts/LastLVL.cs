using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLVL : MonoBehaviour
{
    public static bool Lastlvl = false;

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "LVL3")
        {
            Lastlvl = true;
        }
    }

}
