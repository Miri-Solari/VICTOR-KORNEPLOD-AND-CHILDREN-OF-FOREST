using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class LizardMove : MonoBehaviour
{
    public Animator Yascher;
    public Transform target;
    private NavMeshAgent agent;
    public float followDistance = 2.0f;
    public float Speed = 3.5f;
    public bool IsInCharge = false;
    private bool isMovementActivated = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToTarget.TargetReachedEvent += ActivateMovement;
    }

    void OnDestroy()
    {
        MoveToTarget.TargetReachedEvent -= ActivateMovement;
    }

    void ActivateMovement(float time)
    {
        isMovementActivated = true;
        StartCoroutine(Follow());
    }

    IEnumerator Follow()
    {
        while (isMovementActivated)
        {
            if (!IsInCharge && TryFindLeader(out Transform leader))
            {
                Vector3 followPoint = leader.position - (leader.forward * followDistance);
                agent.destination = followPoint;
            }
            else
            {
                agent.destination = target.position;
            }

            yield return null;
        }
    }

    bool TryFindLeader(out Transform leader)
    {
        RaycastHit hit;
        leader = null;
        if (Physics.Raycast(transform.position, transform.forward, out hit, followDistance))
        {
            if (hit.collider.CompareTag("lizard") && hit.transform != this.transform)
            {
                leader = hit.collider.transform;
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        Yascher.SetFloat("Blend", agent.velocity.magnitude / agent.speed);
        
        if (!isMovementActivated) return;

        agent.speed = Speed;
        agent.stoppingDistance = 0.1f;
        agent.angularSpeed = 200f;


        agent.updatePosition = true;
        agent.updateRotation = true;


        agent.autoTraverseOffMeshLink = true;

        if (agent.velocity != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 15.0f); // Плавный поворот, долго до этого додумывался
        }
    }
}
