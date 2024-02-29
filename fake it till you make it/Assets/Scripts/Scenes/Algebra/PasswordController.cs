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
    public TextMeshProUGUI formulation4Text;
    public TextMeshProUGUI formulation5Text;

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

    public string GeneratePasswordRoom4(int[,] roomMatrix, int[] eigenVector)
    {
        string password = CalculateEigenvalue(roomMatrix, eigenVector).ToString();

        string eigenvector = "[" + eigenVector[0] + ", " + eigenVector[1] + "]";

        PrintFormulation4(eigenvector);
        Debug.Log(password);
        return password;
    }

    public string GeneratePasswordRoom5(int[,] roomMatrix)
    {
        string password = (CalculateDeterminant3x3(roomMatrix)).ToString();

        PrintFormulation5();
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

    static int CalculateEigenvalue(int[,] roommatrix, int[] eigenvector)
    {
        int rows = roommatrix.GetLength(0);
        int cols = roommatrix.GetLength(1);
        int eigenvalue = 0;

        for (int i = 0; i < rows; i++)
        {
            eigenvalue += roommatrix[i, i] * eigenvector[i];
        }

        return eigenvalue;
    }

    int CalculateDeterminant3x3(int[,] matrix)
    {

        int a = matrix[0, 0];
        int b = matrix[0, 1];
        int c = matrix[0, 2];
        int d = matrix[1, 0];
        int e = matrix[1, 1];
        int f = matrix[1, 2];
        int g = matrix[2, 0];
        int h = matrix[2, 1];
        int i = matrix[2, 2];

        int determinant = a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);

        return determinant;
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
        formulation3Text.text = formulation;
    }

    public void PrintFormulation4(string eigenvector)
    {
        string formulation = "Calculate the eigenvalue (VAP) of this matrix with the following eigenvector (VEP): " + eigenvector + ".";
        formulation4Text.text = formulation;
    }

    public void PrintFormulation5()
    {
        string formulation = "Calculate the determinant of this 3x3 matrix.";
        formulation5Text.text = formulation;
    }
}
