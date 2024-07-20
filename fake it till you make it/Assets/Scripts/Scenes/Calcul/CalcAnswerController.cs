using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalcAnswerController : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    public CalcQuizManager quizManager;

    public int answer;
    private int confirmedAnswer;

    void Start()
    {
        quizManager = FindObjectOfType<CalcQuizManager>();
    }

    public void SetAnswer(int answerHammer)
    {
        answer = answerHammer;
        answerText.text = "Chosen answer: " + answer.ToString();
    }
    public int GetAnswer()
    {
        int answerConfirmed = answer;
        return answerConfirmed;
    }

    public void ConfirmAnswer(int answer)
    {
        confirmedAnswer = answer;
        quizManager.AnswerQuestion(confirmedAnswer);
    }
}
