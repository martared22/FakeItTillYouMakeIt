using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElectroQuizManager : MonoBehaviour
{
    private List<string> serieAnswers;
    private List<string> paralelAnswers;
    public List<string> selectedAnswers;
    public bool isSerie;

    public int currentProblemIndex;
    public int triesLeft = 5;

    [SerializeField] private GameObject serieText;
    [SerializeField] private GameObject paralelText;
    [SerializeField] private GameObject serieTable;
    [SerializeField] private GameObject paralelTable;
    [SerializeField] private TextMeshProUGUI answerInputField;
    [SerializeField] private TextMeshProUGUI triesText;

    public Image pointsImg;
    public Sprite[] pointsSprites;
    public CalculatorController calculator;
    public GameManager gameManager;

    private void Start()
    {
        currentProblemIndex = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        calculator = FindObjectOfType<CalculatorController>();
        paralelAnswers = new List<string>
        {
            "54.55",
            "0.22",
            "0.12",
            "0.06",
            "0.04"
        };
        serieAnswers = new List<string>
        {
            "100",
            "0.05",
            "1",
            "1.5",
            "2.5"
        };
        InitializeAnswers();
    }

    private void InitializeAnswers()
    {
        isSerie = Random.Range(0, 2) == 0;
        if (isSerie)
        {
            Debug.Log("is serie");
            serieText.SetActive(true);
            paralelText.SetActive(false);
            serieTable.SetActive(true);
            paralelTable.SetActive(false);
            selectedAnswers = serieAnswers;
        }
        else
        {
            Debug.Log("is paralel");
            paralelText.SetActive(true);
            serieText.SetActive(false);
            paralelTable.SetActive(true);
            serieTable.SetActive(false);
            selectedAnswers = paralelAnswers;
        }
    }
    public void CorrectAnswerGiven()
    {
        currentProblemIndex++;
        pointsImg.sprite = pointsSprites[currentProblemIndex];
    }

    public void WrongAnswerGiven()
    {
        triesLeft--;
    }

    private void Update()
    {
        gameManager.electroPoints = currentProblemIndex;

        if (triesLeft == 0)
        {
            bool levelFailed = true;
            PlayerPrefs.SetInt("LevelVisited_" + "Electro", 1);
            PlayerPrefs.SetInt("failed", levelFailed ? 1 : 0);
            PlayerPrefs.Save();

            levelFailed = false;
            SceneManager.LoadScene("PopupScene");
        }
        else if (currentProblemIndex >= 5)
        {
            Debug.Log("Quiz completed!");
            PlayerPrefs.SetInt("LevelVisited_" + "Electro", 1);
            PlayerPrefs.SetInt("completed", true ? 1 : 0);
            PlayerPrefs.Save();

            SceneManager.LoadScene("PopupScene");
        }
    }
}