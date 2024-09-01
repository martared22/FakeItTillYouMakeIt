using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

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

    public bool[] pageUnlocked;
    public int playerCoins;

    public Image blurOverlay;

    public GameObject coinIconPrefab;
    public Button coinButton;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.FindAnyObjectByType<GameManager>();
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        pauseMenu = FindObjectOfType<PauseMenuController>();
        animator = docBook.GetComponent<Animator>();
        playerCoins = gameManager.totalPoints;

        docBook.SetActive(false);
        isPaused = false;
        eventSystem = EventSystem.current;

        totalPages = pagePanels.Length;

        pageUnlocked = new bool[totalPages];
        LoadPageUnlockStatus();

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
            SetupPageContent(currentPagePanelLeft);
            currentPagePanelLeft.SetActive(true);

            if (currentPage + 1 < totalPages)
            {
                currentPagePanelRight = pagePanels[currentPage + 1];
                SetupPageContent(currentPagePanelRight);
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

    void SetupPageContent(GameObject pagePanel)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        bool isInLobby = currentScene.name == "Lobby";

        if (pageUnlocked[currentPage] || isInLobby || currentPage == 0 || currentPage == 1)
        {
            blurOverlay.gameObject.SetActive(false);
            coinButton.gameObject.SetActive(false);
        }
        else
        {
            blurOverlay.gameObject.SetActive(true);
            coinButton.gameObject.SetActive(true);

            GameObject coinIcon = Instantiate(coinIconPrefab, pagePanel.transform);
            coinIcon.GetComponent<Button>();
        }
    }
    public void UnlockPage()
    {
        int pageIndex;
        pageIndex = currentPage;

        if (playerCoins > 0 && !pageUnlocked[currentPage])
        {
            playerCoins--;
            gameManager.totalPoints--;
            pageUnlocked[pageIndex] = true;
            SavePageUnlockStatus();
            blurOverlay.gameObject.SetActive(false);
            coinButton.gameObject.SetActive(false);
            StartCoroutine(UpdateBookContentWithDelay(0f));
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    void LoadPageUnlockStatus()
    {
        for (int i = 0; i < totalPages; i++)
        {
            pageUnlocked[i] = PlayerPrefs.GetInt("PageUnlocked_" + i, 0) == 1;
        }
    }

    void SavePageUnlockStatus()
    {
        for (int i = 0; i < totalPages; i++)
        {
            PlayerPrefs.SetInt("PageUnlocked_" + i, pageUnlocked[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }
}
