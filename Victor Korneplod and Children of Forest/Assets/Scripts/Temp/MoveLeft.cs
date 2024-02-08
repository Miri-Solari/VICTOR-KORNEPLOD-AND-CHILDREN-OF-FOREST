using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;


    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
    }
}
