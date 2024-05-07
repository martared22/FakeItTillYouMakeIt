using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorController : MonoBehaviour
{
    public bool isPasswordTrue = false;
    public int passwordError = 5;

    public bool levelEnd = false;

    [SerializeField]
    private TextMeshProUGUI passwordText;

    public TextMeshProUGUI triesText;

    private string passwordValue = "";
    private string password;

    private GameObject collidedDoor;

    public GameObject KeyPad;

    public RoomManager roomManager;
    
    private void Start()
    {
        roomManager = GetComponent<RoomManager>();
        KeyPad.SetActive(false);
    }

    private void Update()
    {
        password = roomManager.password;
        passwordText.text = passwordValue;
        triesText.text = "Attempts remaining: " + passwordError.ToString();

        // If the player has entered the correct password, hide the keypad and the door
        if (passwordValue == password)
        {
            isPasswordTrue = true;
            KeyPad.SetActive(false);

            // Reset the password
            passwordText.text = "";
            passwordValue = "";

            // Hide the door
            if (collidedDoor != null)
            {
                collidedDoor.SetActive(false);
            }            
        }
        // If the player has entered the wrong password 5 times, end the level
        else if (passwordValue.Length >= password.Length)
        {
            passwordError --;
            if (passwordError == 0)
            {
                levelEnd = true;
            }

            // Reset the password
            passwordText.text = "";
            passwordValue = "";
        }
    }

    // Show the keypad when the player collides with the door
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Door"))
        {
            if (IsDoorAssociatedWithRoom(collision.gameObject, roomManager.currentRoom))
            {
                KeyPad.SetActive(true);
            }
          
            collidedDoor = collision.gameObject;
        }
    }

    // Hide the keypad when the player leaves the door
    private void OnCollisionExit2D(Collision2D collision)
    {
        KeyPad.SetActive(false);
    }

    // Check if the door is associated with the current room
    private bool IsDoorAssociatedWithRoom(GameObject door, string room)
    {
        int doorNumber = int.Parse(door.name[^1..]);
        int roomNumber = int.Parse(room[^1..]);

        return doorNumber == roomNumber;
    }

    // Add a number to the password
    public void AddNumber(string number)
    {
        passwordValue += number;
    }
}
