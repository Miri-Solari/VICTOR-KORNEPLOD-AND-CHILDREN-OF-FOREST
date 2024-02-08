using System.Text.RegularExpressions;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public float _timeDelay = 7f;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _menu;
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
            //Debug.Log("Победа");
            isVictoryChecked = true;
            if (LastLVL.Lastlvl)
            {
                Invoke(nameof(LastScene), _timeDelay);
                _timeDelay += 10;
            }
            Invoke(nameof(NextScene),_timeDelay);
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

        ENDGAME.EndGame = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void NextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        int sceneNum = Convert.ToInt32(Regex.Match(sceneName, @"\d+").Value);
        ENDGAME.EndGame = false;
        Time.timeScale = 1f;
        if (LastLVL.Lastlvl || sceneName == "Learn2")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (sceneName == "Learn1")
        {
            SceneManager.LoadScene("Learn2");
        }
        else SceneManager.LoadScene($"LVL{sceneNum + 1}");
    }

    public void LastScene()
    {
        SoundManager.Instance.PlayAttackSound(24);
        _gameObject.SetActive(true);
        _menu.SetActive(false);
    }
}