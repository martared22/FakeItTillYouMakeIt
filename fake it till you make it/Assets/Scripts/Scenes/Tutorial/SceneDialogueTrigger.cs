using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SceneDialogueTrigger : MonoBehaviour
{
    Dialogue dialogue = new Dialogue
    {
        npcName = "Teacher",
        sentences = new string[]
        {
            "Good morning new student! You are about to begin one of the most important stages of your life!",
            "Don't worry about the uncertainty you might be feeling, I'm here to guide you along the way and give you some advice.",
            "The most important thing is to always have your notes on hand. By pressing the 'I' key, you'll be able to access all the content needed to pass the exams, as well as the regulations for them.",
            "Once you feel ready, you can approach the door of the subject you want to be evaluated on and enter the classroom to take the test.",
            "If you don't succeed, don't worry. We've all had to go to the resit exam at some point. Here, you'll have another chance to pass the test.",
            "I'm sure you can do it, and you'll be a new person when you're done! We'll see each other at graduation. Good luck!"
        }
    };

    Dialogue dialogueResit = new Dialogue
    {
        npcName = "Teacher",
        sentences = new string[]
        {
            "Congratulations on completing your first attempt! It wasn't too challenging, was it?",
            "I noticed that you didn’t pass all the tests this time, but that’s completely normal. As I mentioned at the beginning of the year, it’s more unusual to pass everything on the first try.",
            "Don’t let the results discourage you. You have the chance to take a resit exam, and I’m confident you can do it! Use this opportunity to prepare thoroughly and give it your best shot.",
            "Remember, this is your final chance, so study hard and play it safe. Good luck!"
        }
    };

    Dialogue dialogueGraduation = new Dialogue
    {
        npcName = "Teacher",
        sentences = new string[]
        {
            "Congratulations on passing all your exams and reaching graduation! Your hard work and dedication have truly paid off, and I’m thrilled to see you achieve this milestone.",
            "Your success is a testament to your commitment and perseverance throughout the year. As you move forward, take pride in your accomplishments and enjoy this moment of celebration.",
            "Best of luck in your future endeavors, and remember that this achievement is just the beginning of many more to come.",
            "Embrace the future with the same determination and enthusiasm you've shown throughout your time here.",
            "Congratulations again, and best wishes for all the exciting opportunities ahead!"
        }
    };

    Dialogue dialogueFailure = new Dialogue
    {
        npcName = "Teacher",
        sentences = new string[]
        {
            "I see that you didn’t pass the resit exam, and I know this is a tough moment. While it’s disappointing, it’s important to remember that this setback isn’t the end of your journey.",
            "Use this experience as an opportunity to reflect, learn, and grow. Every great success story has its challenges and obstacles, and this is just one part of your path.",
            "Stay positive and keep moving forward—there are always alternative routes to achieving your goals, and your determination will guide you to new opportunities.",
            "Embrace the future with the same determination and enthusiasm you've shown throughout your time here.",
            "While this setback is tough, it's not the end of your journey. Best wishes for all the exciting opportunities ahead!"
        }
    };

    private void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        
        if (gameManager.isTutorial)
        {
            TriggerDialogue(dialogue);
            gameManager.isTutorial = false;
        }
        else if (gameManager.AreAllLevelsNotFailed())
        {
            TriggerDialogue(dialogueGraduation);
        }
        else if (!gameManager.AreAllLevelsNotFailed() && !gameManager.isResited)
        {
            TriggerDialogue(dialogueResit);
            gameManager.isResited = true;
        }
        else if (!gameManager.AreAllLevelsNotFailed() && gameManager.isResited)
        {
            TriggerDialogue(dialogueFailure);
            gameManager.isResited = false;
        }
    }

    public void TriggerDialogue(Dialogue dialogueOpt)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueOpt);
    }
}

