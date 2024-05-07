using Cinemachine;
using System;
using System.Collections;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering.Universal;

public class HammerController : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    public CalcAnswerController calcAnswer;
    private Rigidbody2D rb;
    public GameObject ball;

    public TextMeshProUGUI timerText;

    public bool canPress;
    public bool isCharged;
    public float hammerChargeBuildUpRate = 64f;
    public float hammerCharge;

    private float maxY = 0f;

    public double secondsPassed;
    public DateTime startTime;
    public DateTime endTime;
    private float timer = 0f;
    private bool isTiming = false;

    void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        calcAnswer = FindObjectOfType<CalcAnswerController>();
        rb = ball.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (rb.position.y > maxY)
        {
            maxY = rb.position.y;
            int answer = ((int)Math.Round(maxY / 2));
            calcAnswer.SetAnswer(answer);
        }

        if (canPress && inputHandler.InteractInput)
        {
            
            maxY = 0f;
            if (!isTiming)
            {
                StartCoroutine(Timer());
            }
        }
        else if (canPress && !inputHandler.InteractInput && isTiming)
        {
            secondsPassed = timer;
            SwingHammer();            
        }
    }

    IEnumerator Timer()
    {
        isTiming = true;

        while (isTiming)
        {
            timer += Time.deltaTime;
            UpdateUIText();
            yield return null;
        }
        timer = 0f;
    }
    void UpdateUIText()
    { 
        int seconds = Mathf.FloorToInt(timer);
        int milliseconds = Mathf.FloorToInt((timer - seconds) * 1000);

        string time = string.Format("{0:00}:{1:000}", seconds, milliseconds);
        timerText.text = "Time held: " + time;
    }

    void SwingHammer()
    {
        hammerCharge = timer * hammerChargeBuildUpRate;
        hammerCharge = Mathf.Min(hammerCharge, 80f);
        rb.AddForce(new Vector2(0, hammerCharge));      
        isTiming = false;
        hammerCharge = 0;
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
