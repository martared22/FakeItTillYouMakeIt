using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public string currentRoom;
    public string password;

    public MatrixController matrixController;
    public PasswordController passwordController;

    public TextMeshProUGUI matrix1Text;
    public TextMeshProUGUI matrix2Text;
    public TextMeshProUGUI matrix3Text;
    public TextMeshProUGUI matrix4Text;
    public TextMeshProUGUI matrix5Text;

    private int[,] roomMatrix;

    private void Start()
    {
        matrixController = GetComponent<MatrixController>();
        passwordController = GetComponent<PasswordController>();
    }
    public void RoomManagement()
    {
        switch(currentRoom)
        {
            case "room1":

                roomMatrix = matrixController.GenerateRoom1Matrix();
                matrixController.PrintMatrix(roomMatrix, matrix1Text);
                password = passwordController.GeneratePasswordRoom1(roomMatrix);
                
                break;

            case "room2":

                roomMatrix = matrixController.GenerateRoom2Matrix();
                matrixController.PrintMatrix(roomMatrix, matrix2Text);
                password = passwordController.GeneratePasswordRoom2(roomMatrix);
                
                break;

            case "room3":

                break;

            case "room4":

                break;

            case "room5":

                break;

            case "noRoom":

                Debug.Log("No room");
                break;

            default:
                break;
        }
    }
     
}
