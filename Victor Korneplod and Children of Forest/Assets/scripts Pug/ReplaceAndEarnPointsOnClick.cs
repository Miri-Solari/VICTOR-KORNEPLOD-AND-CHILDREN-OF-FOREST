using UnityEngine;
using System.Collections;

public class ReplaceAndEarnPointsOnClick : MonoBehaviour
{
    public GameObject replacementPrefab;
    public int pointsEarned = 2;
    private bool isTargetReached = false; 
    private static bool isTemporarilyBlocked = false; 

    void OnEnable()
    {
        MoveToTarget.TargetReachedEvent += OnTargetReached;
    }

    void OnDisable()
    {
        MoveToTarget.TargetReachedEvent -= OnTargetReached;
    }

    void OnTargetReached(float zatichka)
    {
        isTargetReached = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !TrapManager.Instance.isPlacingTrap && !TrapManager.Instance.isRemovingTrap && !isTargetReached && !isTemporarilyBlocked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                ReplaceObjectAndEarnPoints();
            }
        }
    }

    public static void ActivateTemporaryBlock()
    {
        if (!isTemporarilyBlocked)
        {
            isTemporarilyBlocked = true; // блокировка
            
            new GameObject("TemporaryBlockActivator").AddComponent<TemporaryBlockActivator>();
        }
    }

    void ReplaceObjectAndEarnPoints()
    {
        if (replacementPrefab != null && !isTargetReached && !isTemporarilyBlocked)
        {
            Instantiate(replacementPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            PointsManager.Instance.AddPoints(pointsEarned);
        }
    }

    private class TemporaryBlockActivator : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(TemporaryBlockCoroutine());
        }

        IEnumerator TemporaryBlockCoroutine()
        {
            yield return new WaitForSeconds(5);
            isTemporarilyBlocked = false; 
            Destroy(gameObject); 
        }
    }
}