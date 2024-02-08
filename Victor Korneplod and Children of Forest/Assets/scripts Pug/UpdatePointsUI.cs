using UnityEngine;
using TMPro;

public class UpdatePointsUI : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private PointsManager pointsManager;

    void Start()
    {
        UpdatePointsManagerReference();
        UpdatePointsText();
    }

    void Update()
    {
        UpdatePointsManagerReference();
        UpdatePointsText();
    }

    void UpdatePointsManagerReference()
    {
        if (pointsManager == null)
        {
            pointsManager = FindObjectOfType<PointsManager>();
        }
    }

    void UpdatePointsText()
    {
        if (pointsText != null && pointsManager != null)
        {
            pointsText.text = "Очки: " + pointsManager.points.ToString();
        }
    }
}