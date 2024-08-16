using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public Canvas summary;

    private bool canEnter;
    public string sceneName;

    private PlayerInputHandler inputHandler;
    public bool isLevelDone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            summary.gameObject.SetActive(true);
            canEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(summary != null)
            {
                summary.gameObject.SetActive(false);      
            }
            canEnter = false;
        }
    }

    private void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();

        if (PlayerPrefs.HasKey("LevelVisited_" + sceneName))
        {
            isLevelDone = true;
            GameManager.Instance.SetLevelCompletionStatus(sceneName, true);
        }
    }

    private void Update()
    {
        if (canEnter && !isLevelDone && inputHandler.InteractInput && !GameManager.Instance.GetLevelCompletionStatus(sceneName))
        {
            GameManager.Instance.SavePlayerPosition(transform.position.x);
            PlayerPrefs.SetInt("LevelVisited_" + sceneName, 1);
            SceneManager.LoadScene(sceneName);
        }
    }
}
