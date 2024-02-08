using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public float Delay = 10f;
    public GameObject Menu;
    void Start()
    {
        if (PAUSEPOCHINKA.HystoryPlayedCount < 1)
        {
            SoundManager.Instance.PlaySound(23);
            Invoke(nameof(HideImageStart), Delay);
            PAUSEPOCHINKA.HystoryPlayedCount++;
        }
        else HideImageStart();
    }

    private void HideImageStart()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
