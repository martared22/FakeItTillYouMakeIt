using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatrixController : MonoBehaviour
{
    public int[,] GenerateRoom1Matrix()
    {
        int[,] room1Matrix = new int[5, 5];
        for (int i = 0; i < room1Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < room1Matrix.GetLength(1); j++)
            {
                room1Matrix[i, j] = Random.Range(1, 10);
            }
        }
        return room1Matrix;
    }

    public int[,] GenerateRoom2Matrix()
    {
        int[,] room2Matrix = new int[2, 2];
        for (int i = 0; i < room2Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < room2Matrix.GetLength(1); j++)
            {
                room2Matrix[i, j] = Random.Range(1, 10);
            }
        }
        return room2Matrix;
    }

    public void PrintMatrix(int[,] roomMatrix, TextMeshProUGUI matrixText)
    {
        string output = "";
         
        for (int i = 0; i < roomMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < roomMatrix.GetLength(1); j++)
            {
                output += roomMatrix[i, j].ToString();

                if (j < roomMatrix.GetLength(1) - 1)
                {
                    output += " ";
                }
            }

            if (i < roomMatrix.GetLength(0) - 1)
            {
                output += "\n";
            }
        }
        matrixText.text = output;
    }
}
