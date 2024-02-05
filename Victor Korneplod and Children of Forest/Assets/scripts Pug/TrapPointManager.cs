using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class TrapPointManager : MonoBehaviour
{
    public static TrapPointManager Instance { get; private set; }

    public int currentPoints; 

    
    public TMP_Text pointsText; 

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        UpdatePointsText(); 
    }

    public bool CanSpendPoints(int points)
    {
        return currentPoints >= points;
    }

    public void UsePoints(int points)
    {
        currentPoints -= points;
        UpdatePointsText(); 
    }

    public void AddPoints(int points)
    {
        currentPoints += points;
        UpdatePointsText(); 
    }

    
    void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Очки ловушек: " + currentPoints;
        }
    }
}