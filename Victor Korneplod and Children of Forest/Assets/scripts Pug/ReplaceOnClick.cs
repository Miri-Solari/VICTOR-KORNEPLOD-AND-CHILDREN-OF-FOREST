using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ReplaceOnClick : MonoBehaviour
{
    public GameObject replacementPrefab; // Префаб для замены
    public int pointsCost = 2; // Стоимость замены в очках
    private static bool isTemporarilyBlocked = false; // Переменная для временной блокировки
    private bool isPermanentlyBlocked = false; // Переменная для постоянной блокировки

    void OnEnable()
    {
        MoveToTarget.TargetReachedEvent += PermanentlyBlockReplace;
    }

    void OnDisable()
    {
        MoveToTarget.TargetReachedEvent -= PermanentlyBlockReplace;
    }

    // Метод для постоянной блокировки
    void PermanentlyBlockReplace(float unused)
    {
        isPermanentlyBlocked = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTemporarilyBlocked && !isPermanentlyBlocked && !PAUSEPOCHINKA.ISPAUSED && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                if (PointsManager.Instance.UsePoints(pointsCost))
                {
                    ReplaceObject();
                }
                else
                {
                    Debug.Log("Недостаточно очков для замены.");
                }
            }
        }
    }

    public static void ActivateTemporaryBlock()
    {
        if (!isTemporarilyBlocked)
        {
            isTemporarilyBlocked = true; // Активируем временную блокировку
            var instance = FindObjectOfType<ReplaceOnClick>();
            if (instance != null)
            {
                instance.StartCoroutine(instance.TemporaryBlockCoroutine());
            }
        }
    }

    // Корутина для временной блокировки
    IEnumerator TemporaryBlockCoroutine()
    {
        yield return new WaitForSeconds(5);
        isTemporarilyBlocked = false; // Снимаем временную блокировку
    }

    void ReplaceObject()
    {
        if (replacementPrefab != null)
        {
            Instantiate(replacementPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}