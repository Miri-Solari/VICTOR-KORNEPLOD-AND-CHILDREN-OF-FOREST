using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Transform target;
    public GameObject Bomb;
    public ParticleSystem explosion;

    private Transform StartPos;
    private bool destroy = false;

    private void Start()
    {
        StartPos = transform;
    }
    // Update is called once per frame
    void Update()
    {
        Bomb.transform.localPosition = Vector3.up * Cos2Sin(-(StartPos.position - transform.position).magnitude / (StartPos.position - target.position).magnitude  * 2 + 1);
        
        transform.position = Vector3.Lerp(transform.position, target.position + Vector3.up * 0.5f , 0.02f);

        if((transform.position - target.position - Vector3.up * 0.5f).magnitude < 0.1f && !destroy)
        {
            destroy = true;
            SoundManager.Instance.PlayAttackSound(14);
            explosion.Play();
            //Debug.Log("penis");
            Bomb.transform.localScale = Vector3.zero;
            Invoke("Destroy", 1f);
        }
    }

    float Cos2Sin(float cos)
    {
        return Mathf.Sqrt(1 - cos * cos);
    }

}
