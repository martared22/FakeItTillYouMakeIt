using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRoomDetection : MonoBehaviour
{
    public string roomName;
    public RoomManager roomManager;
    public DoorController doorController;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        doorController = FindObjectOfType<DoorController>();
        roomManager = FindObjectOfType<RoomManager>();
    }

    private void Update()
    {
        gameManager.algebraPoints = roomManager.points;

        if (doorController.levelEnd) {
            Debug.Log("You tried too hard and got no far");
            SceneManager.LoadScene("lobby");
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
                Debug.Log("Congrats!");
                SceneManager.LoadScene("lobby");
            }
        }
    }
}