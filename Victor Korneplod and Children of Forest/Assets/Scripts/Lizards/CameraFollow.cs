using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject _targetLizard;
    void Awake()
    {
        if (_targetLizard == null)
        {
            _targetLizard = GameObject.FindGameObjectWithTag("lizard");
        }
    }

    void Update()
    {
        if (_targetLizard != null)
        {
            var tempV3 = new Vector3(_targetLizard.transform.position.x, transform.position.y, _targetLizard.transform.position.z);
            transform.position = tempV3;
        }
        else
        {
            _targetLizard = GameObject.FindGameObjectWithTag("lizard");
        }
    }
}
