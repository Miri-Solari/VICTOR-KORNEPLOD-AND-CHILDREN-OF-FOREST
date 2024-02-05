using UnityEngine;

public class TargetTimeReceiver : MonoBehaviour
{
    void OnEnable()
    {
        MoveToTarget.TargetReachedEvent += OnTargetReached;
    }

    void OnDisable()
    {
        MoveToTarget.TargetReachedEvent -= OnTargetReached;
    }

    void OnTargetReached(float time)
    {
        Debug.Log($"Цель достигнута за {time} секунд.");
        
    }
}