using UnityEngine;
using UnityEngine.UI;

public class GuideController : MonoBehaviour
{
    public GameObject[] pages; // ������ ������� �����������
    public Button nextButton; // ������ "��������� ��������"
    public Button previousButton; // ������ "���������� ��������"
    public Button closeButton; // ������ "������� �����������"
    public GameObject gameContent; // ������� ������ � ��������� �����������, ������� ����� ��������� ��� �������� �����������

    private int currentPageIndex = 0; // ������� ��������

    void Awake()
    {
        // ��������� ������
        closeButton.onClick.AddListener(CloseGuide);
        nextButton.onClick.AddListener(GoToNextPage);
        previousButton.onClick.AddListener(GoToPreviousPage);

        // ���������� ������ ��� �������� �����������
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
    }

    public void OpenGuide()
    {
        // �������� ����������� � ��������� ������� ������ � �����������
        if (gameContent != null)
            gameContent.SetActive(false);

        SetupGuide(); // ��������� � ����� ������ �������� �����������
    }

    void SetupGuide()
    {
        currentPageIndex = 0;
        ShowCurrentPage();
        previousButton.gameObject.SetActive(false); // ������ ������ "���������� ��������" �� ������ ��������
    }

    void ShowCurrentPage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPageIndex);
        }
        // �������� ��������� ������
        previousButton.gameObject.SetActive(currentPageIndex > 0);
        nextButton.gameObject.SetActive(currentPageIndex < pages.Length - 1);
    }

    public void GoToNextPage()
    {
        if (currentPageIndex < pages.Length - 1)
        {
            currentPageIndex++;
            ShowCurrentPage();
        }
    }

    public void GoToPreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            ShowCurrentPage();
        }
    }

    public void CloseGuide()
    {
        // ������ ��� �������� �����������
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        // �������� ������� ������ � ����������� ��� �������� �����������
        if (gameContent != null)
            gameContent.SetActive(true);
    }
}