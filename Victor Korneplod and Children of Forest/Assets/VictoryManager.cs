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
            Debug.Log("Победа");
           
        }
    }
}