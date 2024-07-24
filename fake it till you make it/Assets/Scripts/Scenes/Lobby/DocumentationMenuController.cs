using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using Unity.VisualScripting;

public class DocumentationMenuController : MonoBehaviour
{
    [SerializeField]
    
    public GameObject docBook;
    public Button nextButton;
    public Button previousButton;
    public Button[] postIts;

    public GameObject[] pagePanels;
    private GameObject currentPagePanelLeft;
    private GameObject currentPagePanelRight;

    public int currentPage = 0;
    private int totalPages;

    public bool isPaused;

    public float startMenuTime;
    public float currentTime;

    private PlayerInputHandler inputHandler;
    public PauseMenuController pauseMenu;
    private EventSystem eventSystem;

    private Animator animator;

    void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        pauseMenu = FindObjectOfType<PauseMenuController>();
        animator = docBook.GetComponent<Animator>();

        docBook.SetActive(false);
        isPaused = false;
        eventSystem = EventSystem.current;

        totalPages = pagePanels.Length;

        currentPage = GameManager.Instance.LoadCurrentPage();
        StartCoroutine(UpdateBookContentWithDelay(0f));
    }

    void Update()
    {
        if (inputHandler.DocumentationInput && !pauseMenu.isPaused)
        {
            currentTime = Time.time;
            if (isPaused && (startMenuTime + 0.5f < currentTime))
            {
                ResumeGame();
            }
            else if (!isPaused && (startMenuTime + 0.5f < currentTime))
            {
                PauseGame();
            }
        }
        else if (isPaused && pauseMenu.isPaused)
        {
            ResumeGame();
        }
    }
    public void PauseGame()
    {
        docBook.SetActive(true); 
        isPaused = true;
        inputHandler.OnSwitchMap("Gameplay");
        startMenuTime = Time.time;
    }

    public void ResumeGame()
    {
        docBook.SetActive(false); 
        isPaused = false;        
        startMenuTime = Time.time;
        inputHandler.OnSwitchMap("GameplayKeyboard");
        eventSystem.SetSelectedGameObject(null);
    }

    public void NextPage()
    {
        if (currentPage + 2 < totalPages)
        {
            animator.SetTrigger("nextPage");
            currentPage += 2;
            StartCoroutine(UpdateBookContentWithDelay(0.4f));
        }
    }

    public void PreviousPage()
    {
        if (currentPage - 2 >= 0)
        {
            animator.SetTrigger("previousPage");
            currentPage -= 2;
            StartCoroutine(UpdateBookContentWithDelay(0.4f));
        }
    }

    public void GoToPage(int page)
    { 
        if (page < currentPage)
        {
            currentPage = page;
            animator.SetTrigger("previousPage");
            StartCoroutine(UpdateBookContentWithDelay(0.4f));
        }
        else if (page > currentPage)
        {
            currentPage = page;
            animator.SetTrigger("nextPage");
            StartCoroutine(UpdateBookContentWithDelay(0.4f));
        }
    }

    IEnumerator UpdateBookContentWithDelay(float delay)
    {
        foreach (GameObject panel in pagePanels)
        {
            panel.SetActive(false);
        }

        foreach (Button postit in postIts)
        {
            postit.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(delay);

        if (currentPage >= 0 && currentPage < totalPages)
        {
            currentPagePanelLeft = pagePanels[currentPage];
            currentPagePanelLeft.SetActive(true);

            if (currentPage + 1 < totalPages)
            {
                currentPagePanelRight = pagePanels[currentPage + 1];
                currentPagePanelRight.SetActive(true);
            }
            else
            {
                currentPagePanelRight = null;
            }
        }

        foreach (Button postit in postIts)
        {
            postit.gameObject.SetActive(true);
        }

        GameManager.Instance.SaveCurrentPage(currentPage);
    }
}
