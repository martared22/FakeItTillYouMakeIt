using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using TMPro;
using UnityEngine;
using static CalcQuestionManager;
using UnityEngine.UI;

public class CalcQuizManager : MonoBehaviour
{
    public CalcQuestionManager questionManager;

    private CalcQuestion[] questions;
    private int[] selectedQuestionIndexes;
    private int currentQuestionIndex;

    private bool pointAddedForCurrentQuestion = false;

    // public GameManager gameManager;
    public int points = 0;

    public SpriteRenderer functionImageRenderer;
    public TextMeshProUGUI questionText;

    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        questionManager = gameObject.GetComponent<CalcQuestionManager>();
        selectedQuestionIndexes = questionManager.selectedQuestionIndexes;
        currentQuestionIndex = 0;

        questions = new CalcQuestion[selectedQuestionIndexes.Length];

        ShowNextQuestion();
    }

    void Update()
    {
        //gameManager.biePoints = points;
    }

    private void QuestionQuiz()
    {
        
    }

    public void ShowNextQuestion()
    {
        if (currentQuestionIndex < selectedQuestionIndexes.Length)
        {
            questions[currentQuestionIndex] = questionManager.ReturnQuestion(selectedQuestionIndexes[currentQuestionIndex]);

            questionText.text = "Question " + (currentQuestionIndex + 1) + ": " + questions[currentQuestionIndex].questionText;
            functionImageRenderer.sprite = questions[currentQuestionIndex].functionImage;

            Debug.Log("correct answer" + questions[currentQuestionIndex].correctAnswer);

            pointAddedForCurrentQuestion = false;
        }
    }

    public void AnswerQuestion(int selectedAnswerIndex)
    {
        StartCoroutine(ProcessAnswer(selectedAnswerIndex));
    }

    IEnumerator ProcessAnswer(int confirmedAnswer)
    {
        if (questions != null && currentQuestionIndex >= 0 && currentQuestionIndex < questions.Length && questions[currentQuestionIndex] != null)
        {
            if (confirmedAnswer == questions[currentQuestionIndex].correctAnswer)
            {
                if (!pointAddedForCurrentQuestion)
                {
                    points++;
                    currentQuestionIndex++;
                    pointAddedForCurrentQuestion = true;
                }
            }
            else
            {
                currentQuestionIndex++;
            }
        }
        
        yield return new WaitForSeconds(2f);
        ShowNextQuestion();
    }
}
