using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private void Update()
    {
        canvas.transform.LookAt(Camera.main.transform.position);
    }


}
