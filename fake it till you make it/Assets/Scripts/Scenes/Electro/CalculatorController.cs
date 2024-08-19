using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatorController : MonoBehaviour
{
    public bool isPasswordTrue = false;

    [SerializeField]
    private TextMeshProUGUI passwordText;
    private string solutionValue = "";

    void Update()
    {
        passwordText.text = solutionValue;
    }

    public void AddNumber(string number)
    {
        solutionValue += number;
    }
}
