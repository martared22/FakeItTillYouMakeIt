using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        TriggerDialogue();        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}

