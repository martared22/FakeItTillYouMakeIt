using System.Collections;
using TMPro;
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
    private bool answerCheck;

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
            if (isAnswered && answerCheck)
            {
                points++;
                Debug.Log("Points added: " + points);
            }

            if (currentQuestionIndex == -1)
            {
                ShowNextQuestion();
            }
            else
            {
                yield return new WaitForSeconds(2f);
                ShowNextQuestion();
            }
            
            timer = 10f;
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

        if (isAnswered && answerCheck)
        {
            points++;
            Debug.Log("Points added: " + points);
        }

        yield return new WaitForSeconds(2f);

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
        StartCoroutine(ProcessAnswer(selectedAnswerIndex));
    }

    IEnumerator ProcessAnswer(int selectedAnswerIndex)
    {
        Color correctColor = Color.green;
        Color incorrectColor = Color.red;
        Color defaultColor = Color.white;

        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI currentAnswerText = GetAnswerText(i);

            if (i == selectedAnswerIndex)
            {
                if (i == questions[currentQuestionIndex].correctAnswerIndex)
                {
                    answerCheck = true;
                    SetTextColor(currentAnswerText, correctColor);
                }
                else
                {
                    answerCheck = false;
                    SetTextColor(currentAnswerText, incorrectColor);
                }
            }
            else
            {
                SetTextColor(currentAnswerText, defaultColor);
            }
        }

        isAnswered = true;
        yield return new WaitForSeconds(2f);

        SetTextColor(answer0Text, Color.white);
        SetTextColor(answer1Text, Color.white);
        SetTextColor(answer2Text, Color.white);
        SetTextColor(answer3Text, Color.white);
    }

    TextMeshProUGUI GetAnswerText(int selectedAnswerIndex)
    {
        switch (selectedAnswerIndex)
        {
            case 0:
                return answer0Text;
            case 1:
                return answer1Text;
            case 2:
                return answer2Text;
            case 3:
                return answer3Text;
            default:
                return null;
        }
    }

    void SetTextColor(TextMeshProUGUI text, Color color)
    {
        text.color = color;
    }
}
