using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    private bool canEnter;
    public string sceneName;

    private PlayerInputHandler inputHandler;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(sceneName);
            canEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canEnter = false;
        }
    }

    private void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        if (canEnter && inputHandler.InteractInput)
        {
            Debug.Log(sceneName);

            SceneManager.LoadScene(sceneName);
        }
    }
}
