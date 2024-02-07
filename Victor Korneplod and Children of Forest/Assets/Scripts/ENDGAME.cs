using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDGAME : MonoBehaviour
{
    public static bool EndGame = false;
    public GameObject Manager;  

    private void OnTriggerEnter(Collider other)
    {
        if (!EndGame)
        {
            Manager.GetComponent<VictoryManager>().Lose();
            EndGame = true;
        }

    }
}
