using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONTDESTROYONLOADE : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    
}
