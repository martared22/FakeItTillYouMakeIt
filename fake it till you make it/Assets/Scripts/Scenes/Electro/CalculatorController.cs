using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatorController : MonoBehaviour
{
    public bool isPasswordTrue = false;
    public bool levelEnd = false;

    [SerializeField] private TextMeshProUGUI passwordText;
    [SerializeField] private TextMeshProUGUI triesText;
    [SerializeField] private TextMeshProUGUI correctAnswersText;

    private string passwordValue = "";
    private int passwordError;
    private bool isInputLocked = false;
    private ElectroQuizManager electroQuiz;

    private void Start()
    {
        electroQuiz = FindObjectOfType<ElectroQuizManager>();
        passwordError = electroQuiz.triesLeft;
        UpdateTriesText();
    }

    public void AddNumber(string number)
    {
        if (!isInputLocked)
        {
            if (char.IsDigit(number[0]) || number == ".")
            {
                passwordValue += number;
                passwordText.text = passwordValue;

                int currentIndex = electroQuiz.currentProblemIndex;
                string correctAnswer = electroQuiz.selectedAnswers[currentIndex];
                if (passwordValue.Length == correctAnswer.Length)
                {
                    SubmitPassword();
                }
            }
        }
    }

    public void RemoveLastCharacter()
    {
        if (!isInputLocked && passwordValue.Length > 0)
        {
            passwordValue = passwordValue.Substring(0, passwordValue.Length - 1);
            passwordText.text = passwordValue;
        }
    }

    public void SubmitPassword()
    {
        CheckPassword();
    }

    private void CheckPassword()
    {
        int currentIndex = electroQuiz.currentProblemIndex;
        List<string> currentAnswers = electroQuiz.selectedAnswers;

        if (passwordValue == currentAnswers[currentIndex])
        {
            isPasswordTrue = true;
            UpdateCorrectAnswersText(passwordValue);
            electroQuiz.CorrectAnswerGiven();
        }
        else
        {
            passwordError--;
            electroQuiz.WrongAnswerGiven();
            UpdateTriesText();
            if (passwordError == 0)
            {
                levelEnd = true;
            }
        }
        StartCoroutine(ResetPasswordWithDelay());
    }

    private IEnumerator ResetPasswordWithDelay()
    {
        isInputLocked = true; 
        yield return new WaitForSeconds(1f);
        ResetPassword();
        isInputLocked = false;
    }

    private void ResetPassword()
    {
        passwordText.text = "";
        passwordValue = "";
    }

    private void UpdateTriesText()
    {
        triesText.text = "Attempts remaining: " + passwordError.ToString();
    }
    private void UpdateCorrectAnswersText(string correctAnswer)
    {
        correctAnswersText.text += correctAnswer + "\n";
    }
}
