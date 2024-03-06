using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] possibleAnswers;
        public int correctAnswerIndex;
    }

    public int totalQuestions = 10;
    public int questionIndex;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerText;

    public Question[] questions;
    private Question currentQuestion;

    public QuizManager quizManager;

    private Question GetRandomQuestion()
    {
        questionIndex = Random.Range(0, questions.Length);
        return questions[questionIndex];
    }

    public void StartNewQuestion()
    {
        currentQuestion = GetRandomQuestion();

        Debug.Log(currentQuestion.questionText);

        questionText.text = currentQuestion.questionText;
        answerText.text = currentQuestion.possibleAnswers[0];

        for (int i = 0; i < currentQuestion.possibleAnswers.Length; i++)
        {
            Debug.Log("Option " + (i + 1) + ": " + currentQuestion.possibleAnswers[i]);
        }
    }
    public void CheckAnswer(int selectedAnswerIndex)
    {
        int correctAnswerIndex = questions[questionIndex].correctAnswerIndex;

        if (selectedAnswerIndex == correctAnswerIndex)
        {
            // Correct answer
            Debug.Log("correct");

        }
        else
        {
            // Incorrect answer
            Debug.Log("incorrect");

        }

        totalQuestions--;
        // Move to the next question
        //StartNewQuestion();

    }

    private void Update()
    {
        if (totalQuestions == 0)
        {
            quizManager.questionsEnded = true;
        }
    }

    void Awake()
    {
        questions = new Question[]
        {
            new Question
            {
                questionText = "What is the first step to identify the Customer Segment?",
                possibleAnswers = new string[]
                {
                    "Identify to whom you are going to present and serve your value proposition.",
                    "Identify the best channel to reach your segment.",
                    "Identify which customer segment is more profitable.",
                    "Identify when you can deliver your value proposition."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Banks can use different approaches to different clients considering their assets, clients with lower assets are part of a bigger group than clients with higher assets, and their necessities differ, so the products and the type of interaction are adapted by the bank. This approach to customer segments is called:",
                possibleAnswers = new string[]
                {
                    "Diversified",
                    "Mass market",
                    "Niche Market",
                    "Segmented"
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "A value proposition is:",
                possibleAnswers = new string[]
                {
                    "The product that creates value for a company.",
                    "The product which is sold the most often by the company.",
                    "The savings of the company.",
                    "The proposition of the cooperation between companies."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "A key element of a value proposition can be:",
                possibleAnswers = new string[]
                {
                    "Price.",
                    "Cost reduction.",
                    "Accessibility.",
                    "All responses are correct."
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "Which of these is NOT one of the basics of a value proposition?",
                possibleAnswers = new string[]
                {
                    "How your product/service improves problems.",
                    "Why to buy from you instead of from your competitors.",
                    "Benefits customers can expect.",
                    "Cost of your services."
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What does 'Channels' refer to in the Business Model Canvas?",
                possibleAnswers = new string[]
                {
                    "The methods through which a startup delivers its value proposition.",
                    "The most frequently sold product by the company.",
                    "The cost-saving strategies of the company.",
                    "The proposition of cooperation between companies."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Why are 'Channels' crucial for a startup in the Business Model Canvas?",
                possibleAnswers = new string[]
                {
                    "Determining the most frequently sold product.",
                    "Establishing savings and cost efficiency.",
                    "Shaping the customer journey and ensuring market reach.",
                    "Proposing collaboration opportunities between companies."
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "Personal assistance is defined as:",
                possibleAnswers = new string[]
                {
                    "An evolved version of self-service, where automation is used to assist the client.",
                    "Assistance largely involving human interaction between the client and the organization.",
                    "An automated process, in which it is likely that an organization will not emphasize personal customer relationships.",
                    "A fully automated process, prioritizing efficiency."
                },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "Key resources are the main inputs that your company uses to create its value proposition, service its customer segment, and deliver the product to the _______.",
                possibleAnswers = new string[]
                {
                    "producer",
                    "customer",
                    "vendor",
                    "deliverer"
                },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "Key resources are the main assets that your company requires to create the _________, and they are usually differentiated from the ones being utilized by your competitors.",
                possibleAnswers = new string[]
                {
                    "revenues",
                    "customer segments",
                    "end product",
                    "BMC"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "Physical resources that could include equipment, inventory, buildings, manufacturing plants, and ______ that enable the business to function.",
                possibleAnswers = new string[]
                {
                    "key partners",
                    "distribution networks",
                    "workers",
                    "customers"
                },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "Which element should key activities be focused on?",
                possibleAnswers = new string[]
                {
                    "Marketing strategy.",
                    "Customer loyalty.",
                    "Supply chain.",
                    "Value creation."
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "Fill in the blank space and choose the correct option from the list below. Within the Business model canvas, key activities are the bridge between your value proposition and ______",
                possibleAnswers = new string[]
                {
                    "Innovation",
                    "Profit",
                    "Customer segments",
                    "Quality check"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the key factor when choosing the most suitable partner?",
                possibleAnswers = new string[]
                {
                    "Resources",
                    "Time",
                    "Communication",
                    "None of the options"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the key element in partnerships described in the following definition: 'Partnerships are healthy and sustainable only if there is a visible gain for both parties'?",
                possibleAnswers = new string[]
                {
                    "Selecting partnerships",
                    "Set expectations",
                    "Clear partnership agreements",
                    "Win-win situation"
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is a type of partnership stipulated between competitors?",
                possibleAnswers = new string[]
                {
                    "Strategic alliances",
                    "Joint-ventures",
                    "Co-opetition",
                    "Buyer-supplier relationship"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "One of the advantages of this type of partnership is that partners share goals and risks. What type of partnership does this statement refer to?",
                possibleAnswers = new string[]
                {
                    "Joint ventures",
                    "Strategic alliances",
                    "Co-opetition",
                    "Buyer-supplier relationship"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Cost structure in the company includes:",
                possibleAnswers = new string[]
                {
                    "Only fixed costs.",
                    "Only variable costs.",
                    "The total costs of the company.",
                    "Sometimes variable costs and sometimes fixed costs."
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "According to cost-oriented costs, the most important element is to:",
                possibleAnswers = new string[]
                {
                    "Decrease the costs.",
                    "Increase the costs.",
                    "Leave the costs at the same level.",
                    "Verify the costs on the market."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Variable costs are directly related to:",
                possibleAnswers = new string[]
                {
                    "Production.",
                    "Rent.",
                    "Salaries.",
                    "Media."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Which of the following are fixed costs?",
                possibleAnswers = new string[]
                {
                    "Amortization/ depreciation of the machinery.",
                    "Use of the materials.",
                    "Cost of the media.",
                    "Cost of salaries."
                },
                correctAnswerIndex = 3
            }
        };
    }
}
