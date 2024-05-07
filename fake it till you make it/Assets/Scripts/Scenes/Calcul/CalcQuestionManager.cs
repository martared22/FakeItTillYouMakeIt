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

        int optionsGroupSize = 5;
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
                questionText = "What is the y-intercept of this line?",
                functionImage = Resources.Load<Sprite>("f1.2"),
                correctAnswer = 5
            }
        };
    }
}


