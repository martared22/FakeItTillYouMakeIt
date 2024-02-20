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
    public int points = 0;

    public MatrixController matrixController;
    public PasswordController passwordController;
    public DoorController doorController;

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
        doorController = GetComponent<DoorController>();
    }

    public void RoomManagement()
    {
        switch(currentRoom)
        {
            case "room1":
                if (points < 1)
                {
                    roomMatrix = matrixController.GenerateRoom1Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix1Text);
                    password = passwordController.GeneratePasswordRoom1(roomMatrix);
                    points = 0;
                }
                break;

            case "room2":
                if (points < 1)
                {
                    roomMatrix = matrixController.GenerateRoom2Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix2Text);
                    password = passwordController.GeneratePasswordRoom2(roomMatrix);
                    points = 1;
                }
                break;

            case "room3":

                if (points < 2)
                {
                    roomMatrix = matrixController.GenerateRoom1Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix1Text);
                    password = passwordController.GeneratePasswordRoom1(roomMatrix);
                    points = 2;
                }
                break;

            case "room4":

                if (points < 3)
                {
                    roomMatrix = matrixController.GenerateRoom1Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix1Text);
                    password = passwordController.GeneratePasswordRoom1(roomMatrix);
                    points = 3;
                }
                break;

            case "room5":

                if (points < 4)
                {
                    roomMatrix = matrixController.GenerateRoom1Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix1Text);
                    password = passwordController.GeneratePasswordRoom1(roomMatrix);
                    points = 4;
                }
                break;

            case "ending":

                points = 5;

                break;

            default:
                break;
        }
    }
     
}
