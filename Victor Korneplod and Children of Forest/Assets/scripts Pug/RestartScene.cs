using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void RestartCurrentScene()
    {
     
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

    
        SceneManager.LoadScene(sceneName);
    }
}