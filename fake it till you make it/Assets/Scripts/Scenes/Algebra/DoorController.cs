using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorController : MonoBehaviour
{
    public bool isPasswordTrue = false;

    [SerializeField]
    private TextMeshProUGUI passwordText;

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

        if (passwordValue == password)
        {
            isPasswordTrue = true;
            KeyPad.SetActive(false);

            passwordText.text = "";
            passwordValue = "";
            
            collidedDoor.SetActive(false);            
        }
        else if (passwordValue.Length >= password.Length)
        {
            passwordText.text = "";
            passwordValue = "";
        }
    }

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        KeyPad.SetActive(false);
    }

    private bool IsDoorAssociatedWithRoom(GameObject door, string room)
    {
        string doorname = door.name;
        string roomname = room;

        Debug.Log(doorname + "&" + roomname);
        int doorNumber = int.Parse(door.name[^1..]);
        int roomNumber = int.Parse(room[^1..]);

       

        return doorNumber == roomNumber;
    }

    public void AddNumber(string number)
    {
        passwordValue += number;
    }
}
