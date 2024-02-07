using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{
    public GameObject _menu;
    public void NextClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        int sceneNum = Convert.ToInt32(Regex.Match(sceneName, @"\d+").Value);
        Time.timeScale = 1f;
        GameObject.setActive(false);
        SceneManager.LoadScene($"LVL{sceneNum+1}");
    }
}
