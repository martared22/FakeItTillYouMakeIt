using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DocumentationMenuController : MonoBehaviour
{
    [SerializeField]
    
    public GameObject docBook;
    public Button nextButton;
    public Button previousButton;
    public Button[] bookmarkButtons;
    private int currentPage = 0;
    private int totalPages = 10;

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
        if (currentPage < totalPages - 1)
        {
            animator.SetTrigger("nextPage");
            currentPage++;
            UpdateBookContent();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            animator.SetTrigger("previousPage");
            currentPage--;
            UpdateBookContent();
        }
    }

    public void GoToChapter(int chapterIndex)
    {
        int chapterStartPage = chapterIndex * 2; 
        if (chapterStartPage < totalPages)
        {
            currentPage = chapterStartPage;
            UpdateBookContent();
        }
    }

    void UpdateBookContent()
    {
        // Update the content of the book based on the current page
        // This can be done by enabling/disabling specific page GameObjects or updating Text components
        Debug.Log("Current Page: " + currentPage);
        // Implement your logic to update the book content here
    }
}
