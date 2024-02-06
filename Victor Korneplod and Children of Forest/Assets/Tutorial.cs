using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Guide guide;

    void Start()
    {
        Time.timeScale = 0f;
        guide.ClickFromPause();
        
    }

   
}
