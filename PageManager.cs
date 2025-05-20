using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public CanvasGroup[] pages;
    public Button nextButton;
    public Button prevButton;

    private int currentPage = 0;

    void Start()
    {
        ShowPage(currentPage);
        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PreviousPage);
    }

    void ShowPage(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            bool isCurrent = (i == index);
            pages[i].alpha = isCurrent ? 1 : 0;
            pages[i].interactable = isCurrent;
            pages[i].blocksRaycasts = isCurrent;
        }

        prevButton.interactable = index > 0;
        nextButton.interactable = index < pages.Length - 1;
    }

    void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            ShowPage(currentPage);
        }
    }

    void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        }
    }
}
