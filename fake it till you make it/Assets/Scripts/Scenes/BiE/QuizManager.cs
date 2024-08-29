using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static bieQuestionManager;

public class QuizManager : MonoBehaviour
{
    private bieQuestion[] questions;

    public GameObject[] answerTriggers;
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

    public Image pointsImg;
    public Sprite[] pointsSprites;

    public bieQuestionManager questionManager;
    public GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        questionManager = gameObject.GetComponent<bieQuestionManager>();
        pointsImg = GameObject.Find("points").GetComponent<Image>();

        selectedQuestionIndexes = questionManager.selectedQuestionIndexes;
        currentQuestionIndex = -1;
         
        questions = new bieQuestion[selectedQuestionIndexes.Length];
        StartCoroutine(QuestionTimer());
    }

    private void Update()
    {
        gameManager.biePoints = points;
    }

    IEnumerator QuestionTimer()
    {
        // Loop through all the questions
        while (currentQuestionIndex + 1 < selectedQuestionIndexes.Length)
        {
            // If the question has been answered and the answer is correct, add points
            if (isAnswered && answerCheck)
            {
                points++;
                pointsImg.sprite = pointsSprites[points];
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
            
            timer = 40f;
            isAnswered = false;

            // Loop through the timer until it reaches 0 or the question is answered
            while (timer > 0f && !isAnswered)
            {
                UpdateUIText();
                yield return null;
                timer -= Time.deltaTime;
            }

            // If the question is not answered, show a message
            if (!isAnswered)
            {
                Debug.Log("Time's up!");
            }            
        }

        // If the last question has been answered and the answer is correct, add points
        if (isAnswered && answerCheck)
        {
            points++;
            pointsImg.sprite = pointsSprites[points];
            Debug.Log("Points added: " + points);
        }

        yield return new WaitForSeconds(2f);

        // Save the points and load the popup scene

        Debug.Log("Quiz completed!");
        PlayerPrefs.SetInt("LevelVisited_" + "BiE", 1);
        PlayerPrefs.SetInt("completed", true ? 1 : 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("PopupScene");
    }

    // Update the timer text
    void UpdateUIText()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Show the next question
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

    // Check if the question has been answered and process the answer
    public void AnswerQuestion(int selectedAnswerIndex)
    {
        StartCoroutine(ProcessAnswer(selectedAnswerIndex));
    }

    /* Process the answer:
     * - Disable the answer triggers
     * - Change the color of the selected answer to green if correct, red if incorrect
     * - Enable the answer triggers
     * - Reset the color of the answers
     */
    IEnumerator ProcessAnswer(int selectedAnswerIndex)
    {
        DisableAnswerTriggers();

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
        
        EnableAnswerTriggers();

        SetTextColor(answer0Text, Color.white);
        SetTextColor(answer1Text, Color.white);
        SetTextColor(answer2Text, Color.white);
        SetTextColor(answer3Text, Color.white);
    }

    // Enable the answer triggers
    public void EnableAnswerTriggers()
    {
        foreach (GameObject triggerObject in answerTriggers)
        {
            Collider2D collider = triggerObject.GetComponent<Collider2D>();
            if (collider != null)
                collider.enabled = true;
        }
    }

    // Disable the answer triggers
    public void DisableAnswerTriggers()
    {
        foreach (GameObject triggerObject in answerTriggers)
        {
            Collider2D collider = triggerObject.GetComponent<Collider2D>();
            if (collider != null)
                collider.enabled = false;
        }
    }

    // Get the answer text based on the selected answer index
    TextMeshProUGUI GetAnswerText(int selectedAnswerIndex)
    {
        return selectedAnswerIndex switch
        {
            0 => answer0Text,
            1 => answer1Text,
            2 => answer2Text,
            3 => answer3Text,
            _ => null,
        };
    }

    // Set the text color
    void SetTextColor(TextMeshProUGUI text, Color color)
    {
        text.color = color;
    }
}
