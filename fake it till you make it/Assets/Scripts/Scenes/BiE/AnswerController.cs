using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public int platformIndex;

    private PlayerInputHandler inputHandler;
    public bool canPress;
    public bool cooldown;

    public QuizManager quizManager;

    private void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        quizManager = FindObjectOfType<QuizManager>();
        
    }

    void Update()
    {
        if (inputHandler.InteractInput)
        {
            StartCoroutine(Cooldown());

            if (canPress && cooldown)
            {
                Debug.Log("Button Pressed:" + platformIndex);
                quizManager.AnswerQuestion(platformIndex);
            }
        }
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(1f);
        cooldown = false;
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