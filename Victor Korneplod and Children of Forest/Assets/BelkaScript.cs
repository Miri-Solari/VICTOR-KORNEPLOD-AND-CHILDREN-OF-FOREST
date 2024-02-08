using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelkaScript : MonoBehaviour
{
    public GameObject BombObj;
    public GameObject BombPrefab;
    public Transform target;


    public void Throw(string type)
    {
        if(type == "Disappear")
        {
            BombObj.transform.localScale = Vector3.zero;

            var b = Instantiate(BombPrefab);
            b.GetComponent<BombScript>().target = target;
            b.transform.position = BombObj.transform.position;
        }
        else if(type == "Appear")
        {
            BombObj.transform.localScale = Vector3.one * 1.847349f;
        }
    }

}
