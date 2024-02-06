using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    public float startMenuTime;
    public float currentTime;

    private PlayerInputHandler inputHandler;

    void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
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
        startMenuTime = Time.time;

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); 
        isPaused = false;
        startMenuTime = Time.time;

    }
}
