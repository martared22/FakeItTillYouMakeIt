using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Threading;

public class PlayerRoomDetection : MonoBehaviour
{
    public string roomName;
    public RoomManager roomManager;
    public DoorController doorController;
    public GameManager gameManager;
    private bool levelFailed;
   
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        doorController = FindObjectOfType<DoorController>();
        roomManager = FindObjectOfType<RoomManager>();
    }

    private void Update()
    {
        gameManager.algebraPoints = roomManager.points;

        if (doorController.levelEnd)
        {
            levelFailed = true;
            PlayerPrefs.SetInt("LevelVisited_" + "Algebra", 1);
            PlayerPrefs.SetInt("failed", levelFailed ? 1 : 0);
            PlayerPrefs.Save();

            levelFailed = false;
            SceneManager.LoadScene("PopupScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roomManager.currentRoom = roomName;
            roomManager.RoomManagement();

            if (roomName == "ending")
            {
                bool levelCompleted = true;
                PlayerPrefs.SetInt("LevelVisited_" + "Algebra", 1);
                PlayerPrefs.SetInt("completed", levelCompleted ? 1 : 0);
                PlayerPrefs.Save();

                SceneManager.LoadScene("PopupScene");
            }
        }
    }
}