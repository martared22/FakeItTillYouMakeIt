using System.Collections;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using static QuestionManager;

public class QuizManager : MonoBehaviour
{
    private Question[] questions;
    private int[] selectedQuestionIndexes;
    private int currentQuestionIndex;

    private float timer = 40f;
    public int points = 0;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answer0Text;
    public TextMeshProUGUI answer1Text;
    public TextMeshProUGUI answer2Text;
    public TextMeshProUGUI answer3Text;
    public TextMeshProUGUI timerText;

    private bool isAnswered;

    public QuestionManager questionManager;
    public GameManager gameManager;
   

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        questionManager = gameObject.GetComponent<QuestionManager>();

        selectedQuestionIndexes = questionManager.selectedQuestionIndexes;
        currentQuestionIndex = -1;

        questions = new Question[selectedQuestionIndexes.Length];

        StartCoroutine(QuestionTimer());
    }

    private void Update()
    {
        gameManager.biePoints = points;
    }

    IEnumerator QuestionTimer()
    {
        while (currentQuestionIndex + 1 < selectedQuestionIndexes.Length)
        {
            ShowNextQuestion();

            timer = 40f;
            isAnswered = false;           

            while (timer > 0f && !isAnswered)
            {
                UpdateUIText();
                yield return null;
                timer -= Time.deltaTime;
            }

            if (!isAnswered)
            {
                Debug.Log("Time's up!");
            }
        }
        Debug.Log("Quiz completed!");

        PlayerPrefs.SetInt("completed", true ? 1 : 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("PopupScene");
    }

    void UpdateUIText()
    {

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ShowNextQuestion()
    {

        if (currentQuestionIndex + 1 < selectedQuestionIndexes.Length)
        {
            currentQuestionIndex++;

            questions[currentQuestionIndex] = questionManager.ReturnQuestion(selectedQuestionIndexes[currentQuestionIndex]);

            questionText.text = questions[currentQuestionIndex].questionText;
            answer0Text.text = questions[currentQuestionIndex].possibleAnswers[0];
            answer1Text.text = questions[currentQuestionIndex].possibleAnswers[1];
            answer2Text.text = questions[currentQuestionIndex].possibleAnswers[2];
            answer3Text.text = questions[currentQuestionIndex].possibleAnswers[3];

            Debug.Log(currentQuestionIndex + ": " + questions[currentQuestionIndex].questionText);
            Debug.Log("correct answer" + questions[currentQuestionIndex].correctAnswerIndex);
        }
    }
    public void AnswerQuestion(int selectedAnswerIndex)
    {
        isAnswered = true;

        if (selectedAnswerIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            points++;

            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }
}
