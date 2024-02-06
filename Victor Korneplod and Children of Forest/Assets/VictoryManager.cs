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
            SoundManager.Instance.PlayAttackSound(Random.Range(19, 21));
            Debug.Log("������");
            isVictoryChecked = true;
        }
    }

    public void Lose()
    {
        SoundManager.Instance.PlayAttackSound(Random.Range(17, 19));
        IsLoseChecked=true;
        Invoke(nameof(Restart), 7f);

        
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;


        SceneManager.LoadScene(sceneName);
    }
}