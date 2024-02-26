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
    private Animator anim;

    public GameObject c2;
    public GameObject c3;

    public TextMeshProUGUI matrix1Text;
    public TextMeshProUGUI matrix2Text;
    public TextMeshProUGUI matrix3Text1;
    public TextMeshProUGUI matrix3Text2;
    public TextMeshProUGUI matrix4Text;
    public TextMeshProUGUI matrix5Text;

    public Image pointsImg;
    public Sprite[] pointsSprites;

    private int[,] roomMatrix;
    private int[,] roomMatrix2;
    
    private void Start()
    {
        matrixController = GetComponent<MatrixController>();
        passwordController = GetComponent<PasswordController>();
        doorController = GetComponent<DoorController>();
        pointsImg = GameObject.Find("points").GetComponent<Image>();
    }

    public void RoomManagement()
    {
        switch (currentRoom)
        {
            case "room1":

                if (points < 1)
                {
                    roomMatrix = matrixController.Generate5x5Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix1Text);
                    password = passwordController.GeneratePasswordRoom1(roomMatrix);
                    points = 0;
                    pointsImg.sprite = pointsSprites[0];
                }
                break;

            case "room2":

                if (points < 1)
                {
                    roomMatrix = matrixController.Generate2x2Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix2Text);
                    password = passwordController.GeneratePasswordRoom2(roomMatrix);
                    c2.SetActive(true);
                    points = 1;
                    pointsImg.sprite = pointsSprites[1];
                }
                break;

            case "room3":

                if (points < 2)
                {
                    roomMatrix = matrixController.Generate2x2Matrix();
                    roomMatrix2 = matrixController.Generate2x2Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix3Text1);
                    matrixController.PrintMatrix(roomMatrix2, matrix3Text2);
                    password = passwordController.GeneratePasswordRoom3(roomMatrix, roomMatrix2);
                    c3.SetActive(true);
                    points = 2;
                    pointsImg.sprite = pointsSprites[2];
                }
                break;

            case "room4":

                if (points < 3)
                {
                    roomMatrix = matrixController.Generate5x5Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix1Text);
                    password = passwordController.GeneratePasswordRoom1(roomMatrix);
                    points = 3;
                    pointsImg.sprite = pointsSprites[3];
                }
                break;

            case "room5":

                if (points < 4)
                {
                    roomMatrix = matrixController.Generate5x5Matrix();
                    matrixController.PrintMatrix(roomMatrix, matrix1Text);
                    password = passwordController.GeneratePasswordRoom1(roomMatrix);
                    points = 4;
                    pointsImg.sprite = pointsSprites[4];
                }
                break;

            case "ending":

                points = 5;
                pointsImg.sprite = pointsSprites[5];

                break;

            default:
                break;
        }
    }
     
}
