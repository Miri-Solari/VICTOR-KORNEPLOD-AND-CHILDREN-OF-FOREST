using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ReplaceOnClick : MonoBehaviour
{
    public GameObject replacementPrefab; // ������ ��� ������
    public int pointsCost = 2; // ��������� ������ � �����
    private static bool isTemporarilyBlocked = false; // ���������� ��� ��������� ����������
    private bool isPermanentlyBlocked = false; // ���������� ��� ���������� ����������

    void OnEnable()
    {
        MoveToTarget.TargetReachedEvent += PermanentlyBlockReplace;
    }

    void OnDisable()
    {
        MoveToTarget.TargetReachedEvent -= PermanentlyBlockReplace;
    }

    // ����� ��� ���������� ����������
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
                    Debug.Log("������������ ����� ��� ������.");
                }
            }
        }
    }

    public static void ActivateTemporaryBlock()
    {
        if (!isTemporarilyBlocked)
        {
            isTemporarilyBlocked = true; // ���������� ��������� ����������
            var instance = FindObjectOfType<ReplaceOnClick>();
            if (instance != null)
            {
                instance.StartCoroutine(instance.TemporaryBlockCoroutine());
            }
        }
    }

    // �������� ��� ��������� ����������
    IEnumerator TemporaryBlockCoroutine()
    {
        yield return new WaitForSeconds(5);
        isTemporarilyBlocked = false; // ������� ��������� ����������
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