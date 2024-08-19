using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElectroQuizManager : MonoBehaviour
{
    private List<string> serieAnswers;
    private List<string> paralelAnswers;
    private int currentProblemIndex;
    public bool isSerie;

    public GameObject serieText;
    public GameObject paralelText;
    public GameObject serieTable;
    public GameObject paralelTable;

    void Start()
    {
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

        // Randomly choose between series and parallel mode
        isSerie = Random.Range(0, 2) == 0;

        currentProblemIndex = 0;
        DisplayCurrentProblem();
    }
    public List<string> GetCurrentAnswers()
    {
        return isSerie ? serieAnswers : paralelAnswers;
    }

    public int GetCurrentProblemIndex()
    {
        return currentProblemIndex;
    }

    void DisplayCurrentProblem()
    {
        if (isSerie)
        {
            Debug.Log("is serie");
            serieText.SetActive(true);
            paralelText.SetActive(false);
            serieTable.SetActive(true);
            paralelTable.SetActive(false);
        }
        else
        {
            Debug.Log("is paralel");
            paralelText.SetActive(true);
            serieText.SetActive(false);
            paralelTable.SetActive(true);
            serieTable.SetActive(false);
        }

        //feedbackText.text = ""; // Clear any previous feedback
        //inputField.text = "";   // Clear the input field
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
