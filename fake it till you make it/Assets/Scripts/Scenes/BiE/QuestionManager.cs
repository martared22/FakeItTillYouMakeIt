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

    public int[] selectedQuestionIndexes;

    public Question[] questions;

    void Awake()
    {
        SetQuestions();
        GetQuestions(5);
    }

    public Question ReturnQuestion(int questionIndex)
    {
        return questions[questionIndex];
    }

    private void GetQuestions(int numberOfQuestions)
    {
        selectedQuestionIndexes = new int[numberOfQuestions];
        HashSet<int> selectedIndexesSet = new();

        for (int i = 0; i < numberOfQuestions; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, questions.Length);
            } while (selectedIndexesSet.Contains(randomIndex));

            selectedQuestionIndexes[i] = randomIndex;
            selectedIndexesSet.Add(randomIndex);
        }

        Debug.Log("Selected Question Indexes: " + string.Join(", ", selectedQuestionIndexes));
    }

    private void SetQuestions()
    {
        questions = new Question[]
        {
            new Question
            {
                questionText = "Banks can use different approaches to different clients considering their assets. This approach to customer segments is called:",
                possibleAnswers = new string[]
                {
                    "A: Diversified",
                    "B: Mass market",
                    "C: Niche Market",
                    "D: Segmented"
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "A value proposition is:",
                possibleAnswers = new string[]
                {
                    "A: The product that creates value for a company.",
                    "B: The product which is sold the most often by the company.",
                    "C: The savings of the company.",
                    "D: The proposition of the cooperation between companies."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "A key element of a value proposition can be:",
                possibleAnswers = new string[]
                {
                    "A: Price.",
                    "B: Cost reduction.",
                    "C: Accessibility.",
                    "D: All responses are correct."
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "Which of these is NOT one of the basics of a value proposition?",
                possibleAnswers = new string[]
                {
                    "A: How your product/service improves problems.",
                    "B: Why to buy from you instead of from your competitors.",
                    "C: Benefits customers can expect.",
                    "D: Cost of your services."
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "Key resources are the main inputs that your company uses to create its value proposition, service its customer segment, and deliver the product to the _______.",
                possibleAnswers = new string[]
                {
                    "A: producer",
                    "B: customer",
                    "C: vendor",
                    "D: deliverer"
                },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "Key resources are the main assets that your company requires to create the _______, and they are usually distinct from competitors' choices.",
                possibleAnswers = new string[]
                {
                    "A: Revenues",
                    "B: customer segments",
                    "C: end product",
                    "D: BMC"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "Physical resources that could include equipment, inventory, buildings, manufacturing plants, and _______ that enable the business to function.",
                possibleAnswers = new string[]
                {
                    "A: key partners",
                    "B: distribution networks",
                    "C: workers",
                    "D: customers"
                },
                correctAnswerIndex = 1
            },
            new Question
            {
                questionText = "Which element should key activities be focused on?",
                possibleAnswers = new string[]
                {
                    "A: Marketing strategy.",
                    "B: Customer loyalty.",
                    "C: Supply chain.",
                    "D: Value creation."
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "Within the Business model canvas, key activities are the bridge between your value proposition and ______.",
                possibleAnswers = new string[]
                {
                    "A: Innovation",
                    "B: Profit",
                    "C: Customer segments",
                    "D: Quality check"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the key factor when choosing the most suitable partner?",
                possibleAnswers = new string[]
                {
                    "A: Resources",
                    "B: Time",
                    "C: Communication",
                    "D: None of the options"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "What is the key element in partnerships described in the following definition: 'Partnerships are healthy and sustainable only if there is a visible gain for both parties'?",
                possibleAnswers = new string[]
                {
                    "A: Selecting partnerships",
                    "B: Set expectations",
                    "C: Clear partnership agreements",
                    "D: Win-win situation"
                },
                correctAnswerIndex = 3
            },
            new Question
            {
                questionText = "What is a type of partnership stipulated between competitors?",
                possibleAnswers = new string[]
                {
                    "A: Strategic alliances",
                    "B: Joint-ventures",
                    "C: Co-opetition",
                    "D: Buyer-supplier relationship"
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "One of the advantages of this type of partnership is that partners share goals and risks. What type of partnership does this statement refer to?",
                possibleAnswers = new string[]
                {
                    "A: Joint ventures",
                    "B: Strategic alliances",
                    "C: Co-opetition",
                    "D: Buyer-supplier relationship"
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Cost structure in the company includes:",
                possibleAnswers = new string[]
                {
                    "A: Only fixed costs.",
                    "B: Only variable costs.",
                    "C: The total costs of the company.",
                    "D: Sometimes variable costs and sometimes fixed costs."
                },
                correctAnswerIndex = 2
            },
            new Question
            {
                questionText = "According to cost-oriented costs, the most important element is to:",
                possibleAnswers = new string[]
                {
                    "A: Decrease the costs.",
                    "B: Increase the costs.",
                    "C: Leave the costs at the same level.",
                    "D: Verify the costs on the market."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Variable costs are directly related to:",
                possibleAnswers = new string[]
                {
                    "A: Production.",
                    "B: Rent.",
                    "C: Salaries.",
                    "D: Media."
                },
                correctAnswerIndex = 0
            },
            new Question
            {
                questionText = "Which of the following are fixed costs?",
                possibleAnswers = new string[]
                {
                    "A: Amortization/ depreciation of the machinery.",
                    "B: Use of the materials.",
                    "C: Cost of the media.",
                    "D: Cost of salaries."
                },
                correctAnswerIndex = 3
            }
        };
    }
}

