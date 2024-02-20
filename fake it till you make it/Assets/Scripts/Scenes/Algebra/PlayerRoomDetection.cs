using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRoomDetection : MonoBehaviour
{
    public string roomName;
    public RoomManager roomManager;

    void Start()
    {
        if (roomManager == null)
        {
            roomManager = GetComponent<RoomManager>();
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
                SceneManager.LoadScene("lobby");
            }
        }
    }
}