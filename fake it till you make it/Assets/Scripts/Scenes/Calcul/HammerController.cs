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
    private Rigidbody2D rb;
    public GameObject ball;

    public TextMeshProUGUI answerText;
    public TextMeshProUGUI timerText;

    public bool canPress;
    public bool isCharged;
    public float hammerChargeBuildUpRate = 64f; // 64 pixels per second
    public float hammerCharge;

    private float maxY = 0f;

    public double secondsPassed;
    public DateTime startTime;
    public DateTime endTime;
    private float timer = 0f; // The timer
    private bool isTiming = false;

    void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        rb = ball.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (rb.position.y > maxY)
        {
            maxY = rb.position.y;
            answerText.text = (Math.Round(maxY / 2)).ToString();
        }

        if (canPress && inputHandler.InteractInput)
        {
            
            maxY = 0f;
            if (!isTiming)
            {
                StartCoroutine(Timer()); // Start the timer when the button is initially pressed
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

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void SwingHammer()
    {
        hammerCharge = timer * hammerChargeBuildUpRate;
        hammerCharge = Mathf.Min(hammerCharge, 90f);
        Debug.Log(hammerCharge);
        rb.AddForce(new Vector2(0, hammerCharge));      
        isTiming = false; // Stop the timer when the button is released
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
