using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatrixController : MonoBehaviour
{
    public int[,] GenerateMatrix(int rows, int columns)
    {
        int[,] roomMatrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                roomMatrix[i, j] = Random.Range(1, 10);
            }
        }
        return roomMatrix;
    }

    public int[] GenerateVector()
    {
        int[] eigenVector = new int[2];
        eigenVector[0] = Random.Range(-1, 2);
        eigenVector[1] = Random.Range(-1, 2);

        return eigenVector;
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

    public void PrintVector(int[] vector, TextMeshProUGUI vectorText)
    {
        string output = "";

        for (int i = 0; i < vector.Length; i++)
        {
            output += vector[i].ToString();

            if (i < vector.Length - 1)
            {
                output += " ";
            }
        }

        vectorText.text = output;
    }
}
