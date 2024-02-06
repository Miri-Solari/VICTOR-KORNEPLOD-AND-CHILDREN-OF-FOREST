using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public float Delay = 10f;
    public GameObject Menu;
    void Start()
    {
        Invoke(nameof(HideImageStart), Delay);
    }

    private void HideImageStart()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
