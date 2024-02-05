using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
        public void PlayClick()
        {
            SceneManager.LoadScene("LVL1");
        }
}
