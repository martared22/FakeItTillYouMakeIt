using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject backToLobbyButton;

    public GameObject pauseMenu;
    public bool isPaused;

    public float startMenuTime;
    public float currentTime;

    private PlayerInputHandler inputHandler;

    private EventSystem eventSystem;

    void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        pauseMenu.SetActive(false);
        isPaused = false;
        eventSystem = EventSystem.current;
    }

    void Update()
    {
        if (inputHandler.PauseInput)
        {            
            currentTime = Time.time;
            if (isPaused && (startMenuTime + 0.5f < currentTime) )
            {
                ResumeGame();
            }
            else if (!isPaused && (startMenuTime + 0.5f < currentTime))
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); 
        isPaused = true;
        inputHandler.OnSwitchMap("Gameplay");
        startMenuTime = Time.time;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); 
        isPaused = false;        
        startMenuTime = Time.time;
        inputHandler.OnSwitchMap("GameplayKeyboard");
        eventSystem.SetSelectedGameObject(null);
    }

    public void BackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void OpenOptions()
    {
        GameManager.Instance.ShowOptionsMenu();
    }
}
