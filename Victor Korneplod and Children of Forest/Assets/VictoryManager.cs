using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    private bool isVictoryChecked = false;
    private void Update()
    {
        if (!isVictoryChecked)
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
            Debug.Log("Победа");
            isVictoryChecked = true;
        }
    }

    public void Lose()
    {
        SoundManager.Instance.PlayAttackSound(Random.Range(17, 19));

    }
}