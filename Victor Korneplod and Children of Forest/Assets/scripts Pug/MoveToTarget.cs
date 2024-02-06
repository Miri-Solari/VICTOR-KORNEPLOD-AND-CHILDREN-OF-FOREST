using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class MoveToTarget : MonoBehaviour
{
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
                TargetReachedEvent?.Invoke(totalTime);
                UIbuttons.SetActive(false);
                Destroy(gameObject);
                yield break;
            }

            if (Time.time - startTime > 1000f) 
            {
                Time.timeScale = 1.0f; 
                agent.destination = startPosition;
                yield break;
            }

            yield return null;
        }
    }
}

