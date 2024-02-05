using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousLVL : MonoBehaviour
{
    public void PrevClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        int sceneNum = Convert.ToInt32(Regex.Match(sceneName, @"\d+").Value);
        SceneManager.LoadScene($"LVL{sceneNum + 1}");
    }
}
