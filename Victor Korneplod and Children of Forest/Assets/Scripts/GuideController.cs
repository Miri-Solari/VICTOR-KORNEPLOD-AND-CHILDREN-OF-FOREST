using UnityEngine;
using UnityEngine.UI;

public class GuideController : MonoBehaviour
{
    public GameObject[] pages; // Массив страниц руководства
    public Button nextButton; // Кнопка "Следующая страница"
    public Button previousButton; // Кнопка "Предыдущая страница"
    public Button closeButton; // Кнопка "Закрыть руководство"
    public GameObject gameContent; // Игровой объект с остальным интерфейсом, который нужно отключить при открытии руководства

    private int currentPageIndex = 0; // Текущая страница

    void Awake()
    {
        // Настройка кнопок
        closeButton.onClick.AddListener(CloseGuide);
        nextButton.onClick.AddListener(GoToNextPage);
        previousButton.onClick.AddListener(GoToPreviousPage);

        // Изначально скрыть все страницы руководства
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
    }

    public void OpenGuide()
    {
        // Показать руководство и отключить игровой объект с интерфейсом
        if (gameContent != null)
            gameContent.SetActive(false);

        SetupGuide(); // Настройка и показ первой страницы руководства
    }

    void SetupGuide()
    {
        currentPageIndex = 0;
        ShowCurrentPage();
        previousButton.gameObject.SetActive(false); // Скрыть кнопку "Предыдущая страница" на первой странице
    }

    void ShowCurrentPage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPageIndex);
        }
        // Обновить состояние кнопок
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
        // Скрыть все страницы руководства
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        // Включить игровой объект с интерфейсом при закрытии руководства
        if (gameContent != null)
            gameContent.SetActive(true);
    }
}