using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance { get; private set; }

    public int startPoints = 20; 
    public int points;
    public TMP_Text pointsText;

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

        ResetPoints(); 
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsText();
    }

    public bool UsePoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            UpdatePointsText();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetPoints()
    {
        points = startPoints; 
        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Замен: " + points.ToString();
        }
    }
}