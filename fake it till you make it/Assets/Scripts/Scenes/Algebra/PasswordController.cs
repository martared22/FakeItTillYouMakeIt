using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordController : MonoBehaviour
{
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
            indicesString += passwordRowIndices[i] + "," + passwordColIndices[i];

            if (i < passwordLength - 1)
            {
                indicesString += " ";
            }
        }
        Debug.Log(indicesString);
        Debug.Log(password);

        return password;    
    }

    public string GeneratePasswordRoom2(int[,] roomMatrix)
    {
        string password = (roomMatrix[0, 0] * roomMatrix[1, 1] - roomMatrix[0, 1] * roomMatrix[1, 0]).ToString();

        Debug.Log(password);
        return password;
    }
}
