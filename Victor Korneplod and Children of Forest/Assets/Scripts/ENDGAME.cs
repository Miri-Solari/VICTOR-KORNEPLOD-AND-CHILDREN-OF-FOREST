using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDGAME : MonoBehaviour
{
    public static bool EndGame = false;
    public GameObject Manager;
    private void OnCollisionEnter(Collision collision)
    {
        Manager.GetComponent<VictoryManager>().Lose();
    }
}
