using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    public CalcAnswerController calcAnswer;
    public bool canPress;

    void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        calcAnswer = FindObjectOfType<CalcAnswerController>();
    }

    void Update()
    {
        if (canPress && inputHandler.InteractInput)
        {
            int answer = calcAnswer.GetAnswer();
            calcAnswer.ConfirmAnswer(answer);
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
