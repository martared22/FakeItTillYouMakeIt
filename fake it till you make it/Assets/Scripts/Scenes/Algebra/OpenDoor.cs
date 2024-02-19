using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public bool isAtDoor = false;

    [SerializeField]
    private TextMeshProUGUI passwordText;
    string passwordValue = "";

    private string password;

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

        if(passwordValue == password)
        {
            Debug.Log("correct");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Door1")
        {
            isAtDoor = true;
            Debug.Log("ddoor");
            KeyPad.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isAtDoor = false;
        KeyPad.SetActive(false);
    }

    public void AddNumber(string number)
    {
        passwordValue += number;
    }
}
