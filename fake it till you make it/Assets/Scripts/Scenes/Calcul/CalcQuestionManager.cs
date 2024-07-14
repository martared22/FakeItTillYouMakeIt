using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalcQuestionManager : MonoBehaviour
{
    [System.Serializable]
    public class CalcQuestion
    {
        public string questionText;
        public Sprite functionImage;
        public int correctAnswer;
    }

    public int[] selectedQuestionIndexes;

    public CalcQuestion[] questions;

    void Awake()
    {
        SetQuestions();
        GetQuestions(5);
    }

    public CalcQuestion ReturnQuestion(int questionIndex)
    {
        return questions[questionIndex];
    }

    private void GetQuestions(int numberOfQuestions)
    {
        selectedQuestionIndexes = new int[numberOfQuestions];
        HashSet<int> selectedIndexesSet = new HashSet<int>();

        int optionsGroupSize = 2;
        int currentGroup = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            int startIndex = currentGroup * optionsGroupSize;
            int endIndex = startIndex + optionsGroupSize;

            int randomIndex;
            do
            {
                randomIndex = Random.Range(startIndex, endIndex);
            } while (selectedIndexesSet.Contains(randomIndex));

            selectedQuestionIndexes[i] = randomIndex;
            selectedIndexesSet.Add(randomIndex);
            currentGroup++;
                  
        }
    }

    private void SetQuestions()
    {
        questions = new CalcQuestion[]
        {
            new CalcQuestion
            {
                questionText = "What is the slope of this line?",
                functionImage = Resources.Load<Sprite>("f1.1"),
                correctAnswer = 3
            },
            new CalcQuestion
            {
                questionText = "What is the y-intercept of this line?",
                functionImage = Resources.Load<Sprite>("f1.2"),
                correctAnswer = 5
            },
            new CalcQuestion
            {
                questionText = "At what value of x does the line intercept y = -8?",
                functionImage = Resources.Load<Sprite>("f2.1"),
                correctAnswer = 4
            },
            new CalcQuestion
            {
                questionText = "What is the slope of this line minus 2?",
                functionImage = Resources.Load<Sprite>("f2.2"),
                correctAnswer = 2
            },
            new CalcQuestion
            {
                questionText = "What is the x-coordinate of the point where this line intersects the line y = 2x - 4?",
                functionImage = Resources.Load<Sprite>("f3.1"),
                correctAnswer = 1
            },
            new CalcQuestion
            {
                questionText = "What is the y-coordinate of the point where this line intersects the line y = -2x + 10?",
                functionImage = Resources.Load<Sprite>("f3.2"),
                correctAnswer = 6
            },
            new CalcQuestion
            {
                questionText = "Find the x-coordinate where the derivative equals 0",
                functionImage = Resources.Load<Sprite>("f4.1"),
                correctAnswer = 1
            },
            new CalcQuestion
            {
                questionText = "Find the y-coordinate where the derivative equals 0",
                functionImage = Resources.Load<Sprite>("f4.2"),
                correctAnswer = 4
            },
            new CalcQuestion
            {
                questionText = "What is the period of this function divided by pi?",
                functionImage = Resources.Load<Sprite>("f5.1"),
                correctAnswer = 2
            },
            new CalcQuestion
            {
                questionText = "What is the amplitude of this function?",
                functionImage = Resources.Load<Sprite>("f5.2"),
                correctAnswer = 3
            }
        };
    }
}


