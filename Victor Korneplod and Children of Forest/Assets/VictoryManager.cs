using System.Text.RegularExpressions;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    private bool isVictoryChecked = false;
    private bool IsLoseChecked = false;
    private void Update()
    {
        if (!isVictoryChecked && !IsLoseChecked)
        {
            CheckForVictory();
        }
    }

    private void CheckForVictory()
    {
        GameObject[] lizards = GameObject.FindGameObjectsWithTag("lizard");
        if (lizards.Length == 0)
        {
            ENDGAME.EndGame = true;
            SoundManager.Instance.PlayAttackSound(UnityEngine.Random.Range(19, 21));
            Debug.Log("Победа");
            isVictoryChecked = true;
            Invoke(nameof(NextScene),7f);
        }
    }

    public void Lose()
    {
        SoundManager.Instance.PlayAttackSound(UnityEngine.Random.Range(17, 19));
        IsLoseChecked=true;
        Invoke(nameof(Restart), 7f);

        
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;


        SceneManager.LoadScene(sceneName);
    }

    public void NextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        int sceneNum = Convert.ToInt32(Regex.Match(sceneName, @"\d+").Value);
        SceneManager.LoadScene($"LVL{sceneNum + 1}");
    }
}