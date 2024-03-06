using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIndexData : MonoBehaviour
{
    public int platformIndex;

    private PlayerInputHandler inputHandler;
    public QuizManager quizManager;

    private void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        quizManager.answerSelected = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !quizManager.answerSelected)
        {            
            if (inputHandler.InteractInput)
            {
                Debug.Log("AnwerSelected");
                quizManager.answerIndex = platformIndex;
                quizManager.answerSelected = true;
            }
        }
    }
}