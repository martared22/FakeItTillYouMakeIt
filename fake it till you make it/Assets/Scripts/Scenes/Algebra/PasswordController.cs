using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PasswordController : MonoBehaviour
{
    public TextMeshProUGUI formulation1Text;
    public TextMeshProUGUI formulation2Text;
    public TextMeshProUGUI formulation3Text;

    public string GeneratePasswordRoom1(int[,] roomMatrix)
    {
        int passwordLength = 4;

        string password = "";
        string indicesString = "";

        int[] passwordRowIndices = new int[passwordLength];
        int[] passwordColIndices = new int[passwordLength];

        // Password
        for (int i = 0; i < passwordLength; i++)
        {
            int randomRow = Random.Range(0, roomMatrix.GetLength(0));
            int randomCol = Random.Range(0, roomMatrix.GetLength(1));

            passwordRowIndices[i] = randomRow + 1;
            passwordColIndices[i] = randomCol + 1;

            password += roomMatrix[randomRow, randomCol].ToString();
        }

        // Formulation
        for (int i = 0; i < passwordLength; i++)
        {
            indicesString += "[" + passwordRowIndices[i] + "," + passwordColIndices[i] + "]";

            if (i < passwordLength - 1)
            {
                indicesString += ", ";
            }
        }

        PrintFormulation1(indicesString);
        Debug.Log(password);
        return password;
    }

    public string GeneratePasswordRoom2(int[,] roomMatrix)
    {
        string password = (CalculateDeterminant2x2(roomMatrix)).ToString();

        PrintFormulation2();
        Debug.Log(password);
        return password;
    }

    public string GeneratePasswordRoom3(int[,] roomMatrix, int[,] roomMatrix2)
    {
        int[,] productMatrix = MultiplyMatrices(roomMatrix, roomMatrix2);
        string password = (CalculateDeterminant2x2(productMatrix)).ToString();

        PrintFormulation3();
        Debug.Log(password);
        return password;
    }

    static int CalculateDeterminant2x2(int[,] matrix)
    {
        return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
    }

    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);

        int[,] resultMatrix = new int[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        return resultMatrix;
    }

    public void PrintFormulation1(string indicesString)
    {
        string formulation = "The password consists of the numbers in the following positions " + indicesString + ".";
        formulation1Text.text = formulation;
    }

    public void PrintFormulation2()
    {
        string formulation = "Calculate the determinant of this 2x2 matrix.";
        formulation2Text.text = formulation;
    }

    public void PrintFormulation3()
    {
        string formulation = "Calculate the product matrix and find the determinant.";
        Debug.Log(formulation);
        formulation3Text.text = formulation;
    }
}
