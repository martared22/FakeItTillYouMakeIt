using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public bool answerSelected;
    public bool questionsEnded = false;

    public int answerIndex;
    public QuestionManager questionManager;

    // Start is called before the first frame update
    void Start()
    {
        questionManager.StartNewQuestion();
    }

    private void Update()
    {
        if (answerSelected)
        {
            Debug.Log(answerIndex);
            questionManager.CheckAnswer(answerIndex);
            answerSelected = false;
        }

        if(questionsEnded)
        {
            Debug.Log("GAME ENDED");
        }

    }


}
