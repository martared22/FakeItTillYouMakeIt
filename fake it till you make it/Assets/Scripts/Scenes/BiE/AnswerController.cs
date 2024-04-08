using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public int platformIndex;

    private PlayerInputHandler inputHandler;
    private QuizManager quizManager;

    public bool canPress;

    private void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();        
        quizManager  = FindObjectOfType<QuizManager>();
    }

    void Update()
    {
        if (canPress && inputHandler.InteractInput)
        {
            Debug.Log("Button Pressed:" + platformIndex);
            quizManager.AnswerQuestion(platformIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPress = false;
        }
    }
}