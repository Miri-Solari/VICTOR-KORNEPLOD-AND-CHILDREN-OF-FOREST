using UnityEngine;
using UnityEngine.AI;

public class DynamicNavMeshUpdater : MonoBehaviour
{
    public NavMeshSurface surface;

    void Start()
    {
        UpdateNavMesh(); 
    }

    public void UpdateNavMesh()
    {
        if (surface != null)
        {
            surface.BuildNavMesh(); 
        }
    }

    
}