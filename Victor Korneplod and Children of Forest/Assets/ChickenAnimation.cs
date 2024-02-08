using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAnimation : MonoBehaviour
{
    public GameObject[] eggs;
    public LineRenderer laser;
    public ParticleSystem[] burningEyes;

    public Chiken ChikenScript;


    public float AnimCounter = 0;
    public float addictor = 0;
    private void Update()
    {
        laser.SetPosition(0, eggs[0].transform.position);
        laser.SetPosition(1, eggs[1].transform.position);
        burningEyes[0].transform.localPosition = (eggs[0].transform.localPosition + eggs[1].transform.localPosition) / 2;
        burningEyes[0].transform.LookAt(eggs[0].transform.localPosition, Vector3.up);


        AnimCounter += addictor;
        if (ChikenScript.attack)
        {
            addictor = Mathf.Lerp(addictor, 0.01f, 0.01f);
            eggs[0].transform.localPosition = Vector3.Lerp(eggs[0].transform.localPosition, new Vector3(Mathf.Cos(AnimCounter) * 1.5f, 1f, Mathf.Sin(AnimCounter) * 1.5f), 0.05f);
            eggs[1].transform.localPosition = Vector3.Lerp(eggs[1].transform.localPosition, new Vector3(-Mathf.Cos(AnimCounter) * 1.5f, 1f, -Mathf.Sin(AnimCounter) * 1.5f), 0.05f);

            burningEyes[1].Play();
            burningEyes[2].Play();
        }
        else
        {
            addictor = Mathf.Lerp(addictor, 0f, 0.01f);
            eggs[0].transform.position = Vector3.Lerp(eggs[0].transform.localPosition, Vector3.zero, 0.01f);
            eggs[1].transform.position = Vector3.Lerp(eggs[1].transform.localPosition, Vector3.zero, 0.01f);


            burningEyes[1].Pause();
            burningEyes[2].Pause();
        }
    }


}
