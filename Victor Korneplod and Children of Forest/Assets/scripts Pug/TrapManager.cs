using UnityEngine;

[System.Serializable]
public class TrapCost
{
    public GameObject trapPrefab;
    public int placementCost;
    public int removalReward;
}


public class TrapManager : MonoBehaviour
{
    public static TrapManager Instance { get; private set; }

    public TrapCost[] trapCosts; 
    private GameObject selectedTrapPrefab; 
    private int selectedTrapPlacementCost; 
    private int selectedTrapRemovalReward; 

    public bool isPlacingTrap = false; 
    public bool isRemovingTrap = false;
    private bool blocking = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        MoveToTarget.TargetReachedEvent += BlockRemoval;
    }

    void OnDisable()
    {
        MoveToTarget.TargetReachedEvent -= BlockRemoval;
    }

    public void BlockRemoval(float huita)
    {
        blocking = true;
    }
    public void CancelTrapNode()
    {
        isPlacingTrap = false;
        isRemovingTrap = false;
    }

    public void SelectTrap(int trapIndex)
    {
        if (trapIndex >= 0 && trapIndex < trapCosts.Length)
        {
            selectedTrapPrefab = trapCosts[trapIndex].trapPrefab;
            selectedTrapPlacementCost = trapCosts[trapIndex].placementCost;
            selectedTrapRemovalReward = trapCosts[trapIndex].removalReward;
            isPlacingTrap = true;
            isRemovingTrap = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (isRemovingTrap && hit.collider.gameObject.CompareTag("Trap") && !blocking)
                {
                    TrapPointManager.Instance.AddPoints(selectedTrapRemovalReward);
                    Destroy(hit.collider.gameObject);
                }
                else if (!isRemovingTrap && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground") && isPlacingTrap)
                {
                    if (TrapPointManager.Instance.CanSpendPoints(selectedTrapPlacementCost))
                    {
                        TrapPointManager.Instance.UsePoints(selectedTrapPlacementCost);
                        Instantiate(selectedTrapPrefab, hit.transform.position + Vector3.up * 0.5f, Quaternion.identity);
                        //isPlacingTrap = false; 
                    }
                }
            }
        }
    }

    public void ToggleTrapRemovalMode()
    {
        if (blocking) return;
        isRemovingTrap = !isRemovingTrap;
        if (isRemovingTrap) isPlacingTrap = false; 
    }
}

