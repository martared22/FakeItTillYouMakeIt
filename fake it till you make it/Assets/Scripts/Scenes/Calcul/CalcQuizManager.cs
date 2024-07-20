using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using TMPro;
using UnityEngine;
using static CalcQuestionManager;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalcQuizManager : MonoBehaviour
{
    public CalcQuestionManager questionManager;

    private CalcQuestion[] questions;
    private int[] selectedQuestionIndexes;
    private int currentQuestionIndex;

    private bool pointAddedForCurrentQuestion = false;

    public GameManager gameManager;
    public int points = 0;
    public Image pointsImg;
    public Sprite[] pointsSprites;

    public SpriteRenderer functionImageRenderer;
    public TextMeshProUGUI questionText;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        questionManager = gameObject.GetComponent<CalcQuestionManager>();
        selectedQuestionIndexes = questionManager.selectedQuestionIndexes;
        currentQuestionIndex = 0;

        questions = new CalcQuestion[selectedQuestionIndexes.Length];
        pointsImg = GameObject.Find("points").GetComponent<Image>();

        ShowNextQuestion();
    }

    void Update()
    {
        gameManager.calculPoints = points;
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
                    pointsImg.sprite = pointsSprites[points];
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

        if (currentQuestionIndex == questions.Length)
        {
            Debug.Log("Quiz completed!");

            PlayerPrefs.SetInt("completed", true ? 1 : 0);
            PlayerPrefs.Save();

            SceneManager.LoadScene("PopupScene");
        }
        else
        {
            ShowNextQuestion();
        }
        
    }
}
