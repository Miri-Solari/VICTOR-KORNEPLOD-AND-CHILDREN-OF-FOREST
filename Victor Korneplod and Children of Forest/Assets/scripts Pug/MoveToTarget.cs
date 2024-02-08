using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class MoveToTarget : MonoBehaviour
{
    public static bool active;
    public static event Action<float> TargetReachedEvent;
    public Transform target;
    public float speed = 3.5f;
    private NavMeshAgent agent;
    private Vector3 startPosition;
    public float timeScaleFactor = 10.0f; 
    public GameObject UIbuttons;

    void Start()
    {
        UIbuttons.SetActive(true);
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        agent.speed = speed;
    }

    public void StartMovingTowardsTarget()
    {
        Time.timeScale = timeScaleFactor; 
        active = true;
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        float startTime = Time.time;
        agent.destination = target.position;
        StartCoroutine(CheckIfReachedTarget(startTime));
    }

    IEnumerator CheckIfReachedTarget(float startTime)
    {
        while (true)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget < 1.0f)
            {
                float totalTime = (Time.time - startTime) * timeScaleFactor; 
                Time.timeScale = 1.0f;
                active = false;
                TargetReachedEvent?.Invoke(totalTime);
                UIbuttons.SetActive(false);
                Destroy(gameObject);
                yield break;
            }

            if (Time.time - startTime > 450f) 
            {
                Time.timeScale = 1.0f;
                active = false;
                agent.destination = startPosition;
                SoundManager.Instance.PlaySound(16);
                yield break;
            }

            yield return null;
        }
    }
}

